
using Mall.Core.Domain;
using Mall.Domain.Market;
using Mall.Domain.Market.Repertories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.DomainService
{
    /// <summary>
    /// 销售领域服务
    /// </summary>
    public class MarketService : IDomainService
    {

        public Cart GetCartOfUser(Guid userId)
        {
            var cart = DomainRegistry.Repository<ICartRepository>().GetOfMember(userId);
            if (cart == null)
            {
                cart = new Cart(Guid.NewGuid(), userId, DateTime.Now);
                DomainRegistry.Repository<ICartRepository>().SaveAsync<Guid, Cart>(cart);
            }
            return cart;
        }
    }
}
