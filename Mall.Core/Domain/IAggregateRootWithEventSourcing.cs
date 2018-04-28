using Mall.Core.Domain.Events;
using System;
using System.Collections.Generic;

namespace Mall.Core.Domain
{
    /// <summary>
    /// 聚合根溯源
    /// </summary>
    public interface IAggregateRootWithEventSourcing<TKey> : IAggregateRoot<TKey>, IPurgable, IPersistedVersionSetter
         where TKey : IEquatable<TKey>
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
