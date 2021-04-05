using BuildBlocks.Commons;
using MoneyMenagement.Transactions;
using System.Threading;
using System.Threading.Tasks;

namespace CashierOperationsApplicationLayer.BasicOperationsScenarios.Withdrawal
{
    public class WithdrawalCommandHandler : ICommandHandler<WithdrawalCommand, Transaction>
    {
        private readonly ITransactionDbContext dbContext;
        public WithdrawalCommandHandler(ITransactionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Transaction> Handle(WithdrawalCommand request, CancellationToken cancellationToken)
        {
            var transaction = Transaction.Create(request.Cashier, TransactionType.Withdrawal, request.WithdrawalAmount, cancellationToken);

            var repository = dbContext.Repository;
            await repository.AddAsync(transaction, cancellationToken);
            await dbContext.SaveAsync(cancellationToken);

            return transaction;
        }
    }
}
