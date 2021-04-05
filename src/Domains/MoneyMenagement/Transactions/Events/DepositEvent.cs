using BuildBlocks.DomainEvents;

namespace MoneyMenagement.Transactions.Events
{
    class DepositEvent : IDomainEvent
    {
        public Transaction Transaction { get; private set; }
        public DepositEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}
