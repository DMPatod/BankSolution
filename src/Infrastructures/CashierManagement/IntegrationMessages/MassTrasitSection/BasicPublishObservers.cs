using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection
{
    class BasicPublishObservers : IPublishObserver
    {
        private readonly ILogger<BasicPublishObservers> logger;

        public BasicPublishObservers(ILogger<BasicPublishObservers> logger)
        {
            this.logger = logger;
        }

        public Task PrePublish<T>(PublishContext<T> context) where T : class
        {
            logger.LogInformation($"{context.DestinationAddress} - Message is publishing - messageId={context.MessageId}{Environment.NewLine}" + $"{JsonConvert.SerializeObject(context.Message)}");
            return Task.CompletedTask;
        }

        public Task PostPublish<T>(PublishContext<T> context) where T : class
        {
            logger.LogInformation($"{context.DestinationAddress} - Message is published - messageId={context.MessageId}");
            return Task.CompletedTask;
        }

        public Task PublishFault<T>(PublishContext<T> context, Exception exception) where T : class
        {
            logger.LogError(exception, $"{context.DestinationAddress} - Message could not published - messageId={context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
