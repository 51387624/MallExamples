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
        public AggregateCreatedEvent(object newId)
        {
            this.NewId = newId;
        }

        public object NewId { get; set; }
    }
}
