using BuildBlocks.Commons.Exceptions;
using CashierManagement.Cashiers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.DatabaseContext.SqlServerSection
{
    public class CashierRepository : ICashierRepository
    {
        private readonly EntityDbContext dbContext;
        public CashierRepository(EntityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Cashier> AddAsync(Cashier cashier, CancellationToken cancellationToken)
        {
            cashier.ModifiedAt = DateTime.Now;
            var obj = await dbContext.AddAsync(cashier, cancellationToken);
            return obj.Entity;
        }

        public async Task<Cashier> GetAsync(IpAddress address, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Cashier> GetAsync(int id, CancellationToken cancellationToken)
        {
            var cashier = await dbContext.Set<Cashier>().FirstOrDefaultAsync(ent => ent.Id == id, cancellationToken);
            if (cashier == null)
            {
                throw new NotFoundException<Cashier>();
            }
            return cashier;
        }
    }
}
