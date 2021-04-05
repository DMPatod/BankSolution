using System.Threading;
using System.Threading.Tasks;

namespace MoneyMenagement.Transactions
{
    public interface ITransactionDbContext
    {
        ITransactionRepository Repository { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
