using Mall.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mall.Domain.Market
{
    public class Product:ValueObject
    {
        /// <summary>
        /// ID
        /// </summary>
        public Guid Id { get; }
        /// <summary>
        /// 销售名称
        /// </summary>
        public string SaleName { get;  }
        /// <summary>
        /// 原价
        /// </summary>
        public decimal ShoppePrice { get; }
        /// <summary>
        /// 销售价格
        /// </summary>
        public decimal SalePrice { get; }
        
        public string SaleDescription { get;}
        /// <summary>
        /// 库存
        /// </summary>
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
