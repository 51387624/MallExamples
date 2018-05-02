using Mall.Core.Domain;
using Mall.Domain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.DomainService
{
    /// <summary>
    /// 商品领域服务
    /// </summary>
    public class ProductService:IDomainService
    {
        public Product GetProduct(Guid id)
        {
            return new Product(Guid.NewGuid());
        }
    }
}
