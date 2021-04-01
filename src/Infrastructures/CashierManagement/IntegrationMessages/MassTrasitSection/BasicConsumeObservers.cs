using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.IntegrationMessages.MassTrasitSection
{
    public class BasicConsumeObservers : IConsumeObserver
    {
        private readonly ILogger<BasicConsumeObservers> logger;
        public BasicConsumeObservers(ILogger<BasicConsumeObservers> logger)
        {
            this.logger = logger;
        }
        public Task PreConsume<T>(ConsumeContext<T> context) where T : class
        {
            logger.LogInformation($"{context.ReceiveContext.InputAddress} - Message is consuming - messageId = {context.MessageId}{Environment.NewLine}" +
                                   $"{JsonConvert.SerializeObject(context.Message)}");
            return Task.CompletedTask;
        }
        public Task PostConsume<T>(ConsumeContext<T> context) where T : class
        {
            logger.LogInformation($"{context.ReceiveContext.InputAddress} - Message is consumed - messageId = {context.MessageId}{Environment.NewLine}");
            return Task.CompletedTask;
        }
        public Task ConsumeFault<T>(ConsumeContext<T> context, Exception exception) where T : class
        {
            logger.LogError(exception, $"{context.ReceiveContext.InputAddress} - Message could not consumed - messageId = {context.MessageId}");
            return Task.CompletedTask;
        }
    }
}
