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


        [Test]        
        public void CurrentPrice_WithNoSpecialOffers_IsCorrect()
        {
            var checkout = SetupCheckout();

            checkout.ScanItem("A99");

            Assert.AreEqual(checkout.TotalPrice(), 0.50m);

            checkout.ScanItem("A99");
            Assert.AreEqual(checkout.TotalPrice(), 1.00m);

            checkout.ScanItem("C40");
            Assert.AreEqual(checkout.TotalPrice(), 1.60m);
        }
    }
}