﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Events.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
        }

        public long Sequence { get; set; }

        public string AggregateRootType { get; set; }

        public Guid AggregateRootId { get; set; }

        public Guid Id { get; }

        public DateTime Timestamp { get; }
    }
}
