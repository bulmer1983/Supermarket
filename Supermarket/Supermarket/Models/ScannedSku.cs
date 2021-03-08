using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket.Models
{
    class ScannedSku
    {
        public string Sku { get; set; }
        public int NumberOfScans { get; set; }

        public ScannedSku(string sku, int numberOfScans)
        {
            Sku = sku;
            NumberOfScans = numberOfScans;
        }
    }
}
