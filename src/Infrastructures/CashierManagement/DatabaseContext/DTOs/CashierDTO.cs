using CashierManagement.Cashiers;

namespace CashierManagementInfractureLayer.DatabaseContext.DTOs
{
    public class CashierDTO
    {
        public decimal StoredAmount { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
    }
}
