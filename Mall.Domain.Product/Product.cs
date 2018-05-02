using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Product
{
    public class Product : AggregateRootWithEventSourcing<Guid>
    {
        public Product(Guid id) : 
            base(id)
        {

        }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }
    }
}
