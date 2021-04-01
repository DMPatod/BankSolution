namespace CashierManagement.Cashiers
{
    class CashierCreatedEvent
    {
        public Cashier Cashier { get; private set; }
        public CashierCreatedEvent(Cashier cashier)
        {
            Cashier = cashier;
        }
    }
}
