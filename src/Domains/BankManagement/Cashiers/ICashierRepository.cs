using System;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagement.Cashiers
{
    public interface ICashierRepository
    {
        Task<Cashier> AddAsync(Cashier cashier, CancellationToken cancellationToken);
        Task<Cashier> GetAsync(IpAddress address, CancellationToken cancellationToken);
        Task<Cashier> GetAsync(Guid id, CancellationToken cancellationToken);
    }
}
