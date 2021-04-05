using BuildBlocks.Commons;
using MoneyMenagement.Transactions;
using System.Threading;
using System.Threading.Tasks;

namespace CashierOperationsApplicationLayer.BasicOperationsScenarios.Deposit
{
    public class DepositCommandHandler : ICommandHandler<DepositCommand, Transaction>
    {
        private readonly ITransactionDbContext dbContext;
        public DepositCommandHandler(ITransactionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Transaction> Handle(DepositCommand request, CancellationToken cancellationToken)
        {
            var transaction = Transaction.Create(request.Cashier, TransactionType.Deposit, request.DepositAmount, cancellationToken);

            var repository = dbContext.Repository;
            await repository.AddAsync(transaction, cancellationToken);
            await dbContext.SaveAsync(cancellationToken);

            return transaction;
        }
    }
}
