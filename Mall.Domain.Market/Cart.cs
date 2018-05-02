using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mall.Domain.Market
{
    public class Cart : AggregateRootWithEventSourcing<Guid>
    {
        private readonly List<CartItem> _cartItems;

        public Guid CartId { get; private set; }

        public Guid UserId { get; private set; }

        public DateTime LastChangeTime { get; private set; }

        public Cart(Guid cartId, Guid userId, DateTime lastChangeTime)
            : base(Guid.NewGuid())
        {
            if (cartId == default(Guid))
                throw new ArgumentException("cartId 不能为default(Guid)", "cartId");

            if (userId == default(Guid))
                throw new ArgumentException("userId 不能为default(Guid)", "userId");

            if (lastChangeTime == default(DateTime))
                throw new ArgumentException("lastChangeTime 不能为default(DateTime)", "lastChangeTime");

            this.CartId = cartId;
            this.UserId = userId;
            this.LastChangeTime = lastChangeTime;
            this._cartItems = new List<CartItem>();
        }


        public void AddCartItem(Guid productId, int quantity, decimal price)
        {
            var item = this._cartItems.FirstOrDefault(p => p.ProductId == productId);
            if (item == null)
            {
                item = new CartItem(productId, quantity, price);
                this._cartItems.Add(item);
            }
            else
            {
                item.ModifyPrice(price);
                item.ModifyQuantity(item.Quantity + quantity);
            }
        }
    }
}
