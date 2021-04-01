using CashierManagement.Common;
using System;

namespace CashierManagement.Cashiers
{
    public class Cashier : Aggregate
    {
        public IpAddress Address { get; set; }
        public decimal StoredAmount { get; set; }
        public DateTime StartedOn { get; protected set; }
        public Cashier(IpAddress address, decimal inputedAmount)
        {
            Address = address;
            StoredAmount = inputedAmount;
        }
        public static Cashier Create(IpAddress address, decimal inputedAmount)
        {
            if (inputedAmount < 0)
            {
                throw new Exception("dinheiro nao pode ser menor que zero");
            }
            var cashier = new Cashier(address, inputedAmount);
            //create event
            
            return cashier;
        }
    }
}
