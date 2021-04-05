using BuildBlocks.Commons;
using CashierManagement.Cashiers;

namespace CashierManagementApplicationLayer.ManagementScenarios.ConnectCashier
{
    public class CashierConnectCommand : ICommand<int>
    {
        public IpAddress Address { get; private set; }
        public decimal InitialAmount { get; set; }
        public CashierConnectCommand(IpAddress address, decimal initialAmount)
        {
            Address = address;
            InitialAmount = initialAmount;
        }
    }
}
