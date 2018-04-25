using Mall.Core.Events.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core
{
    public interface IAggregateRootWithEventSourcing : IAggregateRoot, IPurgable, IPersistedVersionSetter
    {
        IEnumerable<IDomainEvent> UncommittedEvents { get; }

        void Replay(IEnumerable<IDomainEvent> events);

        long Version { get; }
    }
}
