using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System;

namespace CashierManagementApplicationLayer.ManagementScenarios.GetCashier
{
    public class CashierGetCommand : ICommand<Cashier>
    {
        public Guid Id { get; private set; }
        public CashierGetCommand(Guid id)
        {
            Id = id;
        }
    }
}
