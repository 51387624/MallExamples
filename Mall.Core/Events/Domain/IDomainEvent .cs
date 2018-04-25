using Mall.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Events.Domain
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public interface IDomainEvent : IEvent
    {
        Guid AggregateRootId { get; set; }
        string AggregateRootType { get; set; }
        long Sequence { get; set; }
    }
}
