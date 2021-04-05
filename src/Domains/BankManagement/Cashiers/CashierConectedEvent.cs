using BuildBlocks.DomainEvents;

namespace CashierManagement.Cashiers
{
    public class CashierConectedEvent : IDomainEvent
    {
        public Cashier Cashier { get; private set; }
        public CashierConectedEvent(Cashier cashier)
        {
            Cashier = cashier;
        }
    }
}
