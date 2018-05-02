using Mall.Core.Domain;
using Mall.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.DomainService
{
    /// <summary>
    /// 领域注册管理器
    /// </summary>
    public class DomainRegistry
    {
        public static TDomainService Service<TDomainService>()
            where TDomainService: IDomainService
        {
            return default(TDomainService);
        }

        public static TRepository Repository<TRepository>()
            where TRepository: IDomainRepository
        {
            return default(TRepository);
        }

        public static ProductService ProductService()
        {
            return new ProductService();
        }

        public static MarketService MarketService()
        {
            return new MarketService();
        }
    }
}
