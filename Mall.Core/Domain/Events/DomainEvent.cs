using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Core.Domain.Events
{
    /// <summary>
    /// 领域事件
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        protected DomainEvent()
        {
            this.Id = Guid.NewGuid();
            this.Timestamp = DateTime.UtcNow;
        }
        /// <summary>
        /// 事件ID
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 事件时间戳
        /// </summary>
        public DateTime Timestamp { get; }
        /// <summary>
        /// 事件时序
        /// </summary>
        public long Sequence { get; set; }
        /// <summary>
        /// 聚合根ID
        /// </summary>
        public object AggregateRootId { get; set; }
        /// <summary>
        /// 聚合根类型
        /// </summary>
        public string AggregateRootType { get; set; }
        
    }
}
