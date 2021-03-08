using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket
{
    public interface ICheckout
    {
        void ScanItem(string Item);
        decimal TotalPrice();

    }
}
