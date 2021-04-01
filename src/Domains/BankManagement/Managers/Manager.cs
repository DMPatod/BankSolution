using CashierManagement.Cashiers;
using System.Collections.Generic;

namespace CashierManagement.Manager
{
    class Manager
    {
        private readonly ICollection<Cashier> cashisers = new List<Cashier>();
        public Cashier Add(Cashier cashier)
        {
            return cashier;
        }
    }
}
