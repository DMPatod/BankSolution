using CashierManagement.Cashiers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.DatabaseContext.SqlServerSection
{
    class CashierRepository : ICashierRepository
    {
        private readonly EntityDbContext dbContext;
        public CashierRepository(EntityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Cashier> AddAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Cashier> GetAsync(IpAddress address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Cashier> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
