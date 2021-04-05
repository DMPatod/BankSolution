using CashierManagement.Commons;
using System;
using System.Threading;

namespace CashierManagement.Cashiers
{
    public class Cashier : Aggregate
    {
        public int Id { get; set; }
        public Guid Guid { get; private set; } = default;
        public IpAddress Address { get; set; }
        public decimal StoredAmount { get; set; }
        public Cashier()
        {
            // Only for EF
        }
        public Cashier(IpAddress address, decimal inputedAmount)
        {
            Address = address;
            StoredAmount = inputedAmount;
        }
        public static Cashier Create(IpAddress address, decimal inputedAmount, CancellationToken cancellationToken)
        {
            if (inputedAmount < 0)
            {
                throw new Exception("dinheiro nao pode ser menor que zero");
            }
            var cashier = new Cashier(address, inputedAmount);
            var createEvent = new CashierConectedEvent(cashier);

            cashier.AddDomainEvent(createEvent);
            return cashier;
        }
        public static Cashier Connect(IpAddress address, decimal inputedAmount, CancellationToken cancellationToken)
        {
            return Create(address, inputedAmount, cancellationToken);
        }
    }
}
