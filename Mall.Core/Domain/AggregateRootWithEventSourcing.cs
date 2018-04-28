
using Mall.Core.Domain;
using Mall.Core.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace Mall.Core.Domain
{
    public abstract class AggregateRootWithEventSourcing<TKey> : IAggregateRootWithEventSourcing<TKey>, IPersistedVersionSetter, IPurgable
         where TKey : IEquatable<TKey>
    {
        #region 私有属性

        private readonly Lazy<Dictionary<string, MethodInfo>> registeredHandlers;
        private readonly Queue<IDomainEvent> uncommittedEvents = new Queue<IDomainEvent>();
        private TKey id;
        private long persistedVersion = 0;
        private object sync = new object();

        #endregion 

        #region 构造函数


        protected AggregateRootWithEventSourcing(TKey id)
        {
            registeredHandlers = new Lazy<Dictionary<string, MethodInfo>>(() =>
            {
                var registry = new Dictionary<string, MethodInfo>();
                var methodInfoList = from mi in this.GetType().GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                                     let returnType = mi.ReturnType
                                     let parameters = mi.GetParameters()
                                     where mi.IsDefined(typeof(HandlesInlineAttribute), false) &&
                                     returnType == typeof(void) &&
                                     parameters.Length == 1 &&
                                     typeof(IDomainEvent).IsAssignableFrom(parameters[0].ParameterType)
                                     select new { EventName = parameters[0].ParameterType.FullName, MethodInfo = mi };

                foreach (var methodInfo in methodInfoList)
                {
                    registry.Add(methodInfo.EventName, methodInfo.MethodInfo);
                }

                return registry;
            });

            Raise(new AggregateCreatedEvent(id));
        }

        #endregion 

        #region 公开属性

        public TKey Id => id;

        long IPersistedVersionSetter.PersistedVersion { set => Interlocked.Exchange(ref this.persistedVersion, value); }

        public IEnumerable<IDomainEvent> UncommittedEvents => uncommittedEvents;

        public long Version => this.uncommittedEvents.Count + this.persistedVersion;

        #endregion 

        #region 公开方法

        public static bool operator != (AggregateRootWithEventSourcing<TKey> a, AggregateRootWithEventSourcing<TKey> b) => !(a == b);
      
        public static bool operator ==(AggregateRootWithEventSourcing<TKey> a, AggregateRootWithEventSourcing<TKey> b)
        {
            if ((object)a == null)
            {
                return (object)b == null;
            }

            return a.Equals(b);
        }

     
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            var other = obj as AggregateRootWithEventSourcing<TKey>;
            if (other == null)
                return false;

            return this.id.Equals(other.id);
        }
     
        public override int GetHashCode() => this.id.GetHashCode();

        void IPurgable.Purge()
        {
            lock (sync)
            {
                uncommittedEvents.Clear();
            }
        }

        public void Replay(IEnumerable<IDomainEvent> events)
        {
            ((IPurgable)this).Purge();
            events.OrderBy(e => e.Timestamp).ToList()
                .ForEach(e =>
                {
                    HandleEvent(e);
                    Interlocked.Increment(ref this.persistedVersion);
                });
        }

        #endregion

        #region 受保护方法

        [HandlesInline]
        protected void OnAggregateCreated(AggregateCreatedEvent @event)
        {
            this.id = (TKey)@event.NewId;
        }

        protected void Raise<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : IDomainEvent
        {
            lock (sync)
            {
                // 首先处理事件数据。
                this.HandleEvent(domainEvent);
                // 聚合的ID值。
                // 然后设置事件的元数据，包括当前事件所对应的聚合根类型以及
                domainEvent.AggregateRootId = this.id;
                domainEvent.AggregateRootType = this.GetType().AssemblyQualifiedName;
                domainEvent.Sequence = this.Version + 1;
                // 最后将事件缓存在“未提交事件”列表中。
                this.uncommittedEvents.Enqueue(domainEvent);
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private void HandleEvent<TDomainEvent>(TDomainEvent domainEvent)
            where TDomainEvent : IDomainEvent
        {
            var key = domainEvent.GetType().FullName;
            if (registeredHandlers.Value.ContainsKey(key))
            {
                registeredHandlers.Value[key].Invoke(this, new object[] { domainEvent });
            }
        }

        #endregion Private Methods
    }
}