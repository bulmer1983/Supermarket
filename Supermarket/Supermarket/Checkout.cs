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
            var offerTotal = _scans.Select(s => GetOfferPrice(s)).Sum();

            var noneOfferTotal = _scans.Select(s => GetItemPrice(s.Sku) * (s.NumberOfScans - QuantityEligibleForOffer(s))).Sum();

            return offerTotal + noneOfferTotal;
        }

        private decimal GetOfferPrice(ScannedSku scannedSku)
        {
            var offer = _specialOffers.FirstOrDefault(o => o.Sku == scannedSku.Sku);
            if (offer is null)
            {
                return 0m;
            }

            var numberOfTimesOfferUsed =  QuantityEligibleForOffer(scannedSku) / offer.Quantity;

            return numberOfTimesOfferUsed * offer.OfferPrice;
                    
        }

        private decimal GetItemPrice(string sku)
        {
            return _items.First(s => s.Sku == sku).Price;
        }


        private int QuantityEligibleForOffer(ScannedSku scannedSku)
        {
            var offer = _specialOffers.FirstOrDefault(o => o.Sku == scannedSku.Sku);

            if (offer is null)
                return 0;
            double s = scannedSku.NumberOfScans / offer.Quantity;
            return (int)Math.Floor(s) * offer.Quantity;

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
