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

            var offers = new List<SpecialOffer>() {
            new SpecialOffer("A99", 3, 1.30m ),
            new SpecialOffer("B15", 2, 0.45m )};

            return new Checkout( items, offers);
        }

        [Test]
        public void WhenItemScanned_WithKnownSku_IsAccepted()
        {
            var checkout = SetupCheckout();
            Assert.DoesNotThrow(() =>
            checkout.ScanItem("A99"));
        }


        [Test]        
        public void TotalPrice_WithNoSpecialOffers_IsCorrect()
        {
            var checkout = SetupCheckout();

            checkout.ScanItem("A99");

            Assert.AreEqual( 0.50m, checkout.TotalPrice());

            checkout.ScanItem("A99");
            Assert.AreEqual( 1.00m, checkout.TotalPrice());

            checkout.ScanItem("C40");
            Assert.AreEqual( 1.60m, checkout.TotalPrice());
        }

        [Test]
        public void WhenItemScanned_WithunKnownSku_Throws()
        {
            var checkout = SetupCheckout();

            Assert.Throws<System.ArgumentException>(() => checkout.ScanItem("Invalid"));
        }


        [Test]
        public void TotalPrice_WithSingleSpecialOffer_IsCorrect()
        {

            var checkout = SetupCheckout();

            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            checkout.ScanItem("A99");
            Assert.AreEqual( 1.30m, checkout.TotalPrice());
        }

        [Test]
        public void TotalPrice_SpecialOfferScannedOutOfSequence_IsCorrect()
        {

            var checkout = SetupCheckout();

            checkout.ScanItem("B15");
            checkout.ScanItem("A99");
            checkout.ScanItem("B15");
            Assert.AreEqual(.95m, checkout.TotalPrice());
        }

    }
}