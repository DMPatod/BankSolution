using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System;

namespace CashierManagementApplicationLayer.ConnectCashier.ManagementScenarios
{
    public class CashierConnectCommand : ICommand<Guid>
    {
        public IpAddress Address { get; private set; }
        public decimal InitialAmount { get; set; }
        public CashierConnectCommand(IpAddress address, decimal initialAmount)
        {
            Address = address;
            InitialAmount = initialAmount;
        }
    }
}
