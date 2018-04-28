using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Market
{
    public class Product:ValueObject
    {
        public Guid Id { get; }
        public string SaleName { get;  }
        public decimal ShoppePrice { get; }

        public decimal SalePrice { get; }
        public string SaleDescription { get;}
        public int Stock { get; }

        public Product(Guid id, string saleName, decimal shoppePrice, decimal salePrice, string saleDescription, int stock)
        {
            this.Id = id;
            this.SaleName = saleName;
            this.ShoppePrice = shoppePrice;
            this.SalePrice = salePrice;
            this.SaleDescription = saleDescription;
            this.Stock = stock;
        }
    }
}
