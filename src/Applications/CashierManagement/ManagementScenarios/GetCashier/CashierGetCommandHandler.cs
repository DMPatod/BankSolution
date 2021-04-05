using BuildBlocks.Commons;
using CashierManagement.Cashiers;
using System.Threading;
using System.Threading.Tasks;

namespace CashierManagementApplicationLayer.ManagementScenarios.GetCashier
{
    class CashierGetCommandHandler : ICommandHandler<CashierGetCommand, Cashier>
    {
        private readonly ICachierDbContext dbContext;
        public CashierGetCommandHandler(ICachierDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Cashier> Handle(CashierGetCommand request, CancellationToken cancellationToken)
        {
            var repository = dbContext.CashierRepository;
            return await repository.GetAsync(request.Id, cancellationToken);
        }
    }
}
