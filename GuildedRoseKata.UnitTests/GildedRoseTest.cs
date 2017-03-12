using GuildedRoseKata.Api.Controllers;
using GuildedRoseKata.Data.Interfaces;
using GuildedRoseKata.Models;
using GuildedRoseKata.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace GuildedRoseKata.UnitTests
{
    [TestClass]
    public class GildedRoseTest
    {
        List<Item> TestItems;
        [TestInitialize()]
        public void TestInit()
        {
            TestItems = new List<Item>();
        }

        [TestMethod()]
        public void SulfurasDoesntGetMessedWithTest()
        {
            TestItems.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(0, results[0].SellIn);
            Assert.AreEqual(80, results[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(1, results[0].Quality);
            Assert.AreEqual(1, results[0].SellIn);
        }

        [TestMethod()]
        public void AgedBrieDoubleIncreasesAfterSellInTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(2, results[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(21, results[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassTenOrLessDaysIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(22, results[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassFiveOrLessDaysIncreasesTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(23, results[0].Quality);
        }

        [TestMethod()]
        public void BackStagePassZeroOrLessDaysResetsTest()
        {
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(0, results[0].Quality);
        }

        [TestMethod()]
        public void AgedBrieAndBackStagePassDoesntExceedFiftyQualityTest()
        {
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 });
            TestItems.Add(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 50 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(50, results[0].Quality);
            Assert.AreEqual(50, results[1].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(6, results[0].Quality);
        }

        [TestMethod()]
        public void NormalItemDecreasesDoubleAfterSellInTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 7 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(5, results[0].Quality);
        }

        [TestMethod()]
        public void ItemQualityNeverNegativeTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 0 });
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = -5 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.IsTrue(results[0].Quality >= 0);
            Assert.IsTrue(results[1].Quality >= 0);
        }

        [TestMethod()]
        public void ItemQualityNeverAboveFiftyTest()
        {
            TestItems.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 0, Quality = 75 });
            TestItems.Add(new Item { Name = "Aged Brie", SellIn = 0, Quality = 75 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.IsTrue(results[0].Quality <= 50);
            Assert.IsTrue(results[1].Quality <= 50);
        }


        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFast()
        {
            TestItems.Add(new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(4, results[0].Quality);
        }

        [TestMethod]
        public void ConjuredItemsDecreaseTwiceAsFastAfterSellIn()
        {
            TestItems.Add(new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 6 });

            var results = BuildDailyOperationsMockAndReturnResults();

            Assert.AreEqual(2, results[0].Quality);
        }

        //Test Helpers

        private List<ItemForSale> BuildDailyOperationsMockAndReturnResults()
        {
            var mockData = new Mock<IItemData>();
            mockData.Setup(x => x.LoadItems()).Returns(TestItems);
            var service = new ItemService(mockData.Object);
            var controller = new DailyOperationController(service);

            var results = controller.Get();
            return results;
        }
    }
}
