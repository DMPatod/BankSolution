using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CashierManagement.DomainEvents
{
    public abstract class DomainEventHolder
    {
        private readonly ConcurrentQueue<IDomainEvent> domainEvents = new ConcurrentQueue<IDomainEvent>();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => domainEvents.ToList().AsReadOnly();
        protected void AddDomainEvent<T>(T domainEvent) where T : IDomainEvent
        {
            domainEvents.Enqueue(domainEvent);
        }
        public bool TryRemoveDomainEvent(out IDomainEvent domainEvent)
        {
            return domainEvents.TryDequeue(out domainEvent);
        }
    }
}
