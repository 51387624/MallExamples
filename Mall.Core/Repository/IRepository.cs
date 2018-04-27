using Mall.Core.Domain;
using System;
using System.Threading.Tasks;

namespace Mall.Core.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// 保存聚合根
        /// </summary>
        /// <typeparam name="TAggregateRoot"></typeparam>
        /// <param name="aggregateRoot"></param>
        /// <returns></returns>
        Task SaveAsync<TAggregateRoot>(TAggregateRoot aggregateRoot)
            where TAggregateRoot : class, IAggregateRootWithEventSourcing;

        Task<TAggregateRoot> GetByIdAsync<TAggregateRoot>(Guid id)
            where TAggregateRoot : class, IAggregateRootWithEventSourcing;
    }
}
