using Mall.Core.Exception;
using Mall.Domain.Market.Repertories;
using Mall.DomainService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mall.Application
{
    public class CartApplication
    {
        public async Task Buy(Guid userId, Guid productId, int quantity)
        {
            var product = DomainRegistry.ProductService().GetProduct(productId);
            if (product == null)
                throw new NotFoundException("对不起,未能获取产品信息,请重试~");

            var cart = DomainRegistry.MarketService().GetCartOfUser(userId);
            cart.AddCartItem(productId, quantity, product.Price);
            await DomainRegistry.Repository<ICartRepository>().SaveAsync<Guid, Domain.Market.Cart>(cart, true);
        }
    }
}
