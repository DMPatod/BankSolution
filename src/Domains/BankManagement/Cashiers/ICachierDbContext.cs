using System.Threading;
using System.Threading.Tasks;

namespace CashierManagement.Cashiers
{
    public interface ICachierDbContext
    {
        ICashierRepository CashierRepository { get; }
        Task SaveAsync(CancellationToken cancellationToken);
    }
}
