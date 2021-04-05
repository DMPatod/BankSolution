using BuildBlocks.Commons;
using CashierManagement.Cashiers;
using MoneyMenagement.Transactions;

namespace CashierOperationsApplicationLayer.BasicOperationsScenarios.Withdrawal
{
    public class WithdrawalCommand : ICommand<Transaction>
    {
        public Cashier Cashier { get; private set; }
        public decimal WithdrawalAmount { get; set; }
        public WithdrawalCommand(Cashier cashier, decimal withdrawalAmount)
        {
            Cashier = cashier;
            WithdrawalAmount = withdrawalAmount;
        }
    }
}
