using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection
{
    public class BasicSendObservers : ISendObserver
    {
        private readonly ILogger<BasicSendObservers> logger;

        public BasicSendObservers(ILogger<BasicSendObservers> logger)
        {
            this.logger = logger;
        }
        public Task PreSend<T>(SendContext<T> context) where T : class
        {
            this.logger.LogInformation($"{context.DestinationAddress} - Message is sending - messageId={context.MessageId}{Environment.NewLine}" + $"{JsonConvert.SerializeObject(context.Message)}");
            return Task.CompletedTask;
        }

        public Task PostSend<T>(SendContext<T> context) where T : class
        {
            this.logger.LogInformation($"{context.DestinationAddress} - Message is sent - messageId={context.MessageId}");
            return Task.CompletedTask;
        }

        public Task SendFault<T>(SendContext<T> context, Exception exception) where T : class
        {
            this.logger.LogError(exception, $"{context.DestinationAddress} - Message could not sent - messageId={context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
