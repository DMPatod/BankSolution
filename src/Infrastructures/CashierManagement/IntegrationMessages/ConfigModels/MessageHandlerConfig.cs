using System;
using System.Collections.Generic;
using System.Linq;

namespace CashierManagementInfractureLayer.IntegrationMessages.ConfigModels
{
    public class MessageHandlerConfig
    {
        public int SelectedIndex { get; set; }
        public List<MessageHandlerOption> MessageHandlerOptions { get; set; } = new List<MessageHandlerOption>();
        public MessageHandlerOption SelectedMessageHandlerOption()
        {
            if (MessageHandlerOptions == null)
            {
                throw new ArgumentNullException(nameof(MessageHandlerOptions));
            }
            if (!MessageHandlerOptions.Any())
            {
                throw new ArgumentException(nameof(MessageHandlerOptions));
            }
            var option = MessageHandlerOptions.FirstOrDefault(o => o.Index == SelectedIndex);
            if (option == null)
            {
                throw new Exception("not found");
            }
            return option;
        }
    }
    public class MessageHandlerOption
    {
        public int Index { get; set; }
        public MessageHandlerTypes HandlerType { get; set; }
        public string HandlerName { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string VirtualHost { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public enum MessageHandlerTypes
    {
        RabbitMq = 1
    }
}
