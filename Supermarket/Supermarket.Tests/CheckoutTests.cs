using NUnit.Framework;
using Supermarket;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        public ICheckout SetupCheckout()
        {
            return new Checkout();
        }

        [Test]
        public void WhenItemScanned_WithKnownSku_IsAccepted()
        {
            var checkout = SetupCheckout();
            Assert.DoesNotThrow(() =>
            checkout.ScanItem("A99"));
        }
    }
}