using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Supermarket
{
    public class Checkout : ICheckout
    {
        private List<ScannedSku> _scans = new List<ScannedSku>();
        private IEnumerable<Item> _items;
        private IEnumerable<SpecialOffer> _specialOffers;

        public Checkout(IEnumerable<Item> items, IEnumerable<SpecialOffer> specialOffers)
        {
            _items = items;
            _specialOffers = specialOffers;
        }

        public decimal TotalPrice()
        {
            return _scans.Select(s => GetItemPrice(s.Sku) * s.NumberOfScans).Sum();
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

            if (_scans.Exists(s => s.Sku == Sku))
                _scans.Find(s => s.Sku == Sku).NumberOfScans++;
            else
                _scans.Add(new ScannedSku(Sku, 1));

        }
    }
}
