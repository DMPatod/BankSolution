using CashierManagement.Commons.Integrations;
using CashierManagementInfractureLayer.IntegrationMessages.ConfigModels;
using CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.IntegrationMessages
{
    public class IntegrationMessageHandler : IIntegrationMessageHandler
    {
        private readonly IBusControl busControl;
        private readonly ConcurrentQueue<IIntegrationMessage> integrationMessagesQueue;
        public IntegrationMessageHandler(IBusControl busControl)
        {
            this.busControl = busControl;
            integrationMessagesQueue = new ConcurrentQueue<IIntegrationMessage>();
        }
        public IReadOnlyCollection<IIntegrationMessage> IntegrationMessages => integrationMessagesQueue.ToList().AsReadOnly();
        public void Add<T>(T message) where T : IIntegrationMessage
        {
            integrationMessagesQueue.Enqueue(message);
        }
        public async Task DistributeAsync(CancellationToken cancellationToken = default)
        {
            while (integrationMessagesQueue.TryDequeue(out var result))
            {
                switch (result)
                {
                    case IIntegrationEvent _:
                        await busControl.Publish(result, result.GetType(), cancellationToken);
                        break;
                    case IIntegrationCommand _:
                        await busControl.Send(result, result.GetType(), cancellationToken);
                        break;
                    default:
                        throw new ArgumentException($"{result.GetType()} is not expected type");
                }
            }
        }
    }
    public static class IntegrationMessageHandlerDIExtension
    {
        public static IServiceCollection AddIntegrationMessageHandler(this IServiceCollection services, MessageHandlerOption option, params Assembly[] assemblies)
        {
            void ConfigureBusFactory(IBusFactoryConfigurator busFactoryConfigurator, IBusRegistrationContext busRegistrationContext)
            {
                foreach (var observer in busRegistrationContext.GetServices<IConsumeObserver>())
                {
                    busFactoryConfigurator.ConnectConsumeObserver(observer);
                }
                foreach (var observer in busRegistrationContext.GetServices<ISendObserver>())
                {
                    busFactoryConfigurator.ConnectSendObserver(observer);
                }
                foreach (var observer in busRegistrationContext.GetServices<IPublishObserver>())
                {
                    busFactoryConfigurator.ConnectPublishObserver(observer);
                }

                busFactoryConfigurator.ConfigureJsonSerializer(settings =>
                {
                    settings.Converters.Add(new MassTransitTypeNameHandlingConverter(TypeNameHandling.Auto));
                    return settings;
                });
                busFactoryConfigurator.ConfigureBsonDeserializer(settings =>
                {
                    settings.Converters.Add(new MassTransitTypeNameHandlingConverter(TypeNameHandling.Auto));
                    return settings;
                });

                busFactoryConfigurator.UseRetry(busFactoryConfigurator, configurator =>
                {
                    configurator.Interval(2, TimeSpan.FromSeconds(3));
                });
            }
            services.AddSingleton(option);

            services.AddSingleton<IConsumeObserver, BasicConsumeObservers>();
            services.AddSingleton<ISendObserver, BasicSendObservers>();
            services.AddSingleton<IPublishObserver, BasicPublishObservers>();

            services.AddMassTransitHostedService();
            services.AddMassTransit(busConfigurator =>
            {
                busConfigurator.AddConsumers(assemblies);
                busConfigurator.AddBus(provider =>
                {
                    IBusControl busControl = default;
                    switch (option.HandlerType)
                    {
                        case MessageHandlerTypes.RabbitMq:
                            busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                            {
                                cfg.Host($"{option.HostName}", option.VirtualHost, hst =>
                                {
                                    hst.Username(option.UserName);
                                    hst.Password(option.Password);
                                    hst.UseCluster(clusterCfg =>
                                    {
                                        clusterCfg.Node($"{option.HostName}:{option.Port}");
                                    });
                                });
                                ConfigureBusFactory(cfg, provider);
                                cfg.ConfigureEndpoints(provider);
                            });
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    return busControl;
                });
            });

            services.TryAddScoped<IIntegrationMessageHandler, IntegrationMessageHandler>();
            return services;
        }
    }
}
