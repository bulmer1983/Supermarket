using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Models
{
    public class SpecialOffer
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal OfferPrice { get; set; }

        public SpecialOffer(string sku, int quantity, decimal offerPrice)
        {
            Sku = sku;
            Quantity = quantity;
            OfferPrice = offerPrice;
        }
    }
}
