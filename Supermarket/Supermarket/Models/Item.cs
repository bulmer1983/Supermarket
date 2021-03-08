using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Models
{
    public class Item
    {
        public string Sku { get; set; }
        public decimal Price { get; set; }

        public Item(string sku, decimal price)
        {
            Sku = sku;
            Price = price;
        }
    }
}
