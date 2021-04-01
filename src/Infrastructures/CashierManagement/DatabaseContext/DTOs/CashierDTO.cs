using CashierManagement.Cashiers;

namespace CashierManagementInfractureLayer.DatabaseContext.DTOs
{
    public class CashierDTO
    {
        public decimal? StoredAmount { get; set; }
        public IpAddress? Address { get; set; }
    }
}
