using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Supermarket
{
    public class Checkout : ICheckout
    {
        private List<string> _scans = new List<string>();
        private IEnumerable<Item> _items;

        public Checkout(IEnumerable<Item> items)
        {
            _items = items;
        }

        public decimal TotalPrice()
        {
            return _scans.Select(s => GetItemPrice(s)).Sum();
        }

        private decimal GetItemPrice(string sku)
        {
            return _items.First(s => s.Sku == sku).Price;
        }


        public void ScanItem(string Item)
        {
            if (!_items.Any(i => i.Sku == Item))
            {
                throw new ArgumentException("Sku not reconsigned");
            }
            _scans.Add(Item);
        }
    }
}
