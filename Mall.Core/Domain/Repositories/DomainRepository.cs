using Mall.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mall.Core.Domain.Repositories
{
    public abstract class DomainRepository : IDomainRepository
    {
        /// <summary>
        /// 消息发布者
        /// </summary>
        private readonly IEventPublisher messagePublisher;

        protected DomainRepository(IEventPublisher messagePublisher)
        {
            this.messagePublisher = messagePublisher;
        }

        public async Task SaveAsync<TKey, IAggregateRootWithEventSourcing>(IAggregateRootWithEventSourcing aggregateRoot, bool purge = true)
            where TKey : IEquatable<TKey>
            where IAggregateRootWithEventSourcing : class, IAggregateRootWithEventSourcing<TKey>, new()
        {
            await this.SaveAggregateAsync<TKey, IAggregateRootWithEventSourcing>(aggregateRoot);
            foreach (var evnt in aggregateRoot.UncommittedEvents)
                await messagePublisher.PublishAsync(evnt);

            if (purge)
                ((IPurgable)aggregateRoot).Purge();
        }

        public async Task<TAggregateRoot> GetByKeyAsync<TKey, TAggregateRoot>(TKey key)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new()
        {
            var result = await this.GetAggregateAsync<TKey, TAggregateRoot>(key);
            ((IPurgable)result).Purge();
            return result;
        }

        protected abstract Task SaveAggregateAsync<TKey, TAggregateRoot>(TAggregateRoot aggregateRoot)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new();

        protected abstract Task<TAggregateRoot> GetAggregateAsync<TKey, TAggregateRoot>(TKey aggregateRootKey)
            where TKey : IEquatable<TKey>
            where TAggregateRoot : class, IAggregateRoot<TKey>, new();
    }
}
