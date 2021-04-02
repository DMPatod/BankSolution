using CashierManagement.Cashiers;
using CashierManagement.Commons.Integrations;
using CashierManagement.DomainEvents;

namespace CashierManagementApplicationLayer.ManagementScenarios.ConnectCashier
{
    public class CashierConnectedIntegrationEvent : IDomainEvent
    {
        public IpAddress Address { get; private set; }
        public decimal InitialAmount { get; set; }
        public CashierConnectedIntegrationEvent(IpAddress address, decimal initialAmount)
        {
            Address = address;
            InitialAmount = initialAmount;
        }
    }
}
