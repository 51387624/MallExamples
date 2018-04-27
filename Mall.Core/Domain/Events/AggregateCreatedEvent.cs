using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Domain.Events
{
    /// <summary>
    /// 聚合创建事件
    /// </summary>
    public sealed class AggregateCreatedEvent : DomainEvent
    {
        public AggregateCreatedEvent(Guid newId)
        {
            this.NewId = newId;
        }

        public Guid NewId { get; set; }
    }
}
