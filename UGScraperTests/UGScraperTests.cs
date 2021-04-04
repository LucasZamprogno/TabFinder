using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace TabFinder.Tests
{
    [TestClass()]
    public class UGScraperTests
    {
        UGScraper scraper;

        [TestInitialize]
        public void Init()
        {
            scraper = new UGScraper();
        }
        [TestMethod()]
        public void GetAllTabsTest()
        {
            BasicSong wetSand = new BasicSong("Red Hot Chili Peppers", "Wet Sand", "Stadium Arcadium");
            BasicSong missMurder = new BasicSong("Miss Murder", "AFI", "DECEMBERUNDERGROUND");
            List<UGTab> res = scraper.GetAllTabs(new List<BasicSong>(){wetSand, missMurder}, UGType.Bass);
            Assert.IsTrue(res.Count > 0);
        }
    }
}