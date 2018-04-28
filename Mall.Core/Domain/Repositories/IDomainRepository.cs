using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mall.Core.Domain.Repositories
{
    /// <summary>
    /// 领域仓储库
    /// </summary>
    public interface IDomainRepository
    {
        Task SaveAsync<TKey, IAggregateRootWithEventSourcing>(IAggregateRootWithEventSourcing aggregateRoot, bool purge = true)
            where TKey : IEquatable<TKey>
            where IAggregateRootWithEventSourcing : class, IAggregateRootWithEventSourcing<TKey>, new();

        Task<IAggregateRoot> GetByKeyAsync<TKey, IAggregateRoot>(TKey key)
            where TKey : IEquatable<TKey>
            where IAggregateRoot : class, IAggregateRoot<TKey>, new();
    }
}
