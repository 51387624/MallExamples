using Mall.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Domain.Events
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public interface IDomainEvent : IEvent
    {
        /// <summary>
        /// 聚合根ID
        /// </summary>
        object AggregateRootId { get; set; }
        /// <summary>
        /// 聚合根类型
        /// </summary>
        string AggregateRootType { get; set; }
        /// <summary>
        /// 事件时序
        /// </summary>
        long Sequence { get; set; }
    }
}
