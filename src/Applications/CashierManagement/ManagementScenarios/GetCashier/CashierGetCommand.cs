using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System;

namespace CashierManagementApplicationLayer.ManagementScenarios.GetCashier
{
    public class CashierGetCommand : ICommand<Cashier>
    {
        public int Id { get; private set; }
        public CashierGetCommand(int id)
        {
            Id = id;
        }
    }
}
