using CashierManagement.Cashiers;
using CashierManagement.DomainEvents;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementApplicationLayer.ManagementScenarios.ConnectCashier
{
    class CashierConnectCommandHandler : ICommandHandler<CashierConnectCommand, int>
    {
        private readonly ICachierDbContext dbContext;
        public CashierConnectCommandHandler(ICachierDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> Handle(CashierConnectCommand request, CancellationToken cancellationToken)
        {
            var cachier = Cashier.Create(request.Address, request.InitialAmount, cancellationToken);

            var repository = dbContext.CashierRepository;
            await repository.AddAsync(cachier, cancellationToken);
            await dbContext.SaveAsync(cancellationToken);

            return cachier.Id;
        }
    }
}
