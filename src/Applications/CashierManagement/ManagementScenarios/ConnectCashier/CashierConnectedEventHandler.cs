using CashierManagement.Cashiers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementApplicationLayer.ConnectCashier.ManagementScenarios
{
    public class CashierConnectedEventHandler : IDomainEventHandler
    {
        private readonly ICachierDbContext dbContext;
        public CashierConnectedEventHandler(ICachierDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Guid> Handle(CashierConnectCommand request, CancellationToken cancellationToken)
        {
            var cashier = Cashier.Create(request.Address, 10.0m);

            var repository = dbContext.CashierRepository;
            await repository.AddAsync(cashier, cancellationToken);

            return cashier.Id;
        }
    }
}
