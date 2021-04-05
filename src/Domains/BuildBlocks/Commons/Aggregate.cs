using BuildBlocks.DomainEvents;
using System;

namespace BuildBlocks.Commons
{
    public class Aggregate : DomainEventHolder
    {
        public DateTime ModifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
