using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void WhenUpdatingQuality_SellInAndQualityAreDecreased()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 1 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void WhenQualityIsZero_ItDoesNotDecrease()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 2, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void WhenSellInHasPassed_QualityDecreasesTwiceAsMuch()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }

        [Test]
        public void AgedBrieInreasesInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 2 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(3, Items[0].Quality);
        }

        [Test]
        public void WhenSellInHasPassed_QualityIncreasesTwiceAsMuch()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 3 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(5, Items[0].Quality);
        }

        [Test]
        public void WhenQualityIsFifty_ItDoesNotIncrease()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 3, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].SellIn);
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void SulfurasNeverSoldsOutOrDecreases()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 3, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].SellIn);
            Assert.AreEqual(30, Items[0].Quality);
        }

        [Test]
        public void BacstageIncreasesInQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[0].SellIn);
            Assert.AreEqual(31, Items[0].Quality);
        }

        [Test]
        public void WhenLessThan10Days_BacstageIncreasesInQualityTwiceAsMuch()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(9, Items[0].SellIn);
            Assert.AreEqual(32, Items[0].Quality);
        }

        [Test]
        public void WhenLessThan5Days_BacstageIncreasesInQualityThreeTimesAsMuch()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(4, Items[0].SellIn);
            Assert.AreEqual(33, Items[0].Quality);
        }

        [Test]
        public void WhenPassed_BacstageDropsToZero()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 6 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(-1, Items[0].SellIn);
            Assert.AreEqual(0, Items[0].Quality);
        }
    }
}
