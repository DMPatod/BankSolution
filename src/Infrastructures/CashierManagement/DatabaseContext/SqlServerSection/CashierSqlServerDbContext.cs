using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementInfractureLayer.DatabaseContext.SqlServerSection
{
    class CashierSqlServerDbContext : ICachierDbContext
    {
        private readonly EntityDbContext dbContext;
        private readonly IDomainMessageHandler messageHandler;
        public CashierSqlServerDbContext(EntityDbContext entityDbContext, IDomainMessageHandler messageHandler)
        {
            dbContext = entityDbContext;
            this.messageHandler = messageHandler;
        }
        public ICashierRepository CashierRepository => new CashierRepository(dbContext);
        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            var eventHolders = dbContext.ChangeTracker.Entries()
                .Where(x => x.Entity is DomainEventHolder)
                .Select(x => (DomainEventHolder)x.Entity)
                .ToList();

            foreach (var eventHolder in eventHolders)
            {
                while (eventHolder.TryRemoveDomainEvent(out var domainEvent))
                {
                    await messageHandler.PublishAsync(domainEvent, cancellationToken);
                }
            }
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
