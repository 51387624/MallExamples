using Mall.Core.Domain.Events;
using System.Collections.Generic;

namespace Mall.Core.Domain
{
    /// <summary>
    /// 聚合根溯源
    /// </summary>
    public interface IAggregateRootWithEventSourcing : IAggregateRoot, IPurgable, IPersistedVersionSetter
    {
        /// <summary>
        /// 未提交事件
        /// </summary>
        IEnumerable<IDomainEvent> UncommittedEvents { get; }

        /// <summary>
        /// 事件回放
        /// </summary>
        /// <param name="events"></param>
        void Replay(IEnumerable<IDomainEvent> events);

        /// <summary>
        /// 版本
        /// </summary>
        long Version { get; }
    }
}
