using CashierManagement.DomainEvents;
using System;

namespace CashierManagement.Commons
{
    public class Aggregate : DomainEventHolder
    {
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
