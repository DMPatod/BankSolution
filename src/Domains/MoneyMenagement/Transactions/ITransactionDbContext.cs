using System.Threading;
using System.Threading.Tasks;

namespace MoneyMenagement.Transactions
{
    public interface ITransactionDbContext
    {
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
