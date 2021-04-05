using BuildBlocks.DomainEvents;

namespace MoneyMenagement.Transactions.Events
{
    public class WithdrawlEvent : IDomainEvent
    {
        public Transaction Transaction { get; private set; }
        public WithdrawlEvent(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}
