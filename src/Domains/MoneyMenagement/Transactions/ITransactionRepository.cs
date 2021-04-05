using System;
using System.Threading;
using System.Threading.Tasks;

namespace MoneyMenagement.Transactions
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetAsync(Guid id, CancellationToken cancellationToken);
        Task<Transaction> AddAsync(Transaction transaction, CancellationToken cancellationToken);
    }
}
