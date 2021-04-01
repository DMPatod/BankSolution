using CashierManagement.Commons.Integrations;
using CashierManagementInfractureLayer.IntegrationMessages.ConfigModels;
using CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.IntegrationMessages
{
    public class IntegrationMessageHandler : IIntegrationMessageHandler
    {
        public IReadOnlyCollection<IIntegrationMessage> IntegrationMessages => throw new System.NotImplementedException();

        public void Add<T>(T message) where T : IIntegrationMessage
        {
            throw new System.NotImplementedException();
        }

        public Task DistributeAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
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
            services.AddMassTransist();

            services.TryAddScoped<IIntegrationMessageHandler, IntegrationMessageHandler>();
            return services;
        }
    }
}
