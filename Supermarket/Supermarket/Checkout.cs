using System;
using System.Collections.Generic;
using System.Linq;


namespace Supermarket
{
    public class Checkout : ICheckout
    {
        private List<string> _scans = new List<string>();

        public decimal TotalPrice()
        {
            throw new NotImplementedException();
        }

        public void ScanItem(string Item)
        {
            _scans.Add(Item);
        }
    }
}
