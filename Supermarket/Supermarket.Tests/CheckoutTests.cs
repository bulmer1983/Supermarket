using NUnit.Framework;
using Supermarket;
using Supermarket.Models;
using System.Collections.Generic;

namespace Supermarket.Tests
{
    public class CheckoutTests
    {
        public ICheckout SetupCheckout()
        {
            var items = new List<Item>(){
            new Item("A99", 0.50m ),
            new Item("B15", 0.30m ),
            new Item("C40", 0.60m ) };

            return new Checkout(items);
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