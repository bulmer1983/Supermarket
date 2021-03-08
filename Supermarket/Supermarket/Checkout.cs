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
        private IEnumerable<SpecialOffer> _specialOffers;

        public Checkout(IEnumerable<Item> items, IEnumerable<SpecialOffer> specialOffers)
        {
            _items = items;
            _specialOffers = specialOffers;
        }

        public decimal TotalPrice()
        {
            return _scans.Select(s => GetItemPrice(s)).Sum();
        }

        private decimal GetItemPrice(string sku)
        {
            return _items.First(s => s.Sku == sku).Price;
        }


        public void ScanItem(string Sku)
        {
            if (!_items.Any(i => i.Sku == Sku))
            {
                throw new ArgumentException("Sku not reconsigned");
            }
            _scans.Add(Sku);
        }
    }
}
