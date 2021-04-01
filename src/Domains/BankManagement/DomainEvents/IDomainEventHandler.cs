namespace CashierManagement.DomainEvents
{
    interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
    }
}
