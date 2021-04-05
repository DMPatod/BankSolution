using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System;

namespace CashierManagementApplicationLayer.ManagementScenarios.ConnectCashier
{
    public class CashierConnectCommand : ICommand<int>
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
