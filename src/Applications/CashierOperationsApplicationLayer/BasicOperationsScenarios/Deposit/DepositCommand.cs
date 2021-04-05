using BuildBlocks.Commons;
using CashierManagement.Cashiers;
using MoneyMenagement.Transactions;

namespace CashierOperationsApplicationLayer.BasicOperationsScenarios.Deposit
{
    public class DepositCommand : ICommand<Transaction>
    {
        public Cashier Cashier { get; private set; }
        public decimal DepositAmount { get; set; }
        public DepositCommand(Cashier cashier, decimal depositAmount)
        {
            Cashier = cashier;
            DepositAmount = depositAmount;
        }
    }
}
