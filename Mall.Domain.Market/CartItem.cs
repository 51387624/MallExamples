using Mall.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Market
{
    public class CartItem:IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; private set; }
        public int Quantity { get; private set; }

        public decimal Price { get; private set; }

        public CartItem(Guid productId, int quantity, decimal price)
        {
            if (productId == default(Guid))
                throw new ArgumentException("productId不能为Guid.Empty", "productId");

            if (quantity <= 0)
                throw new ArgumentException("数量不能小于等于0", "quantity");

            if (price < 0)
                throw new ArgumentException("价格不能小于0", "price");

            this.Id = Guid.NewGuid();
            this.ProductId = productId;
            this.Quantity = quantity;
            this.Price = price;
        }

        public void ModifyQuantity(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
