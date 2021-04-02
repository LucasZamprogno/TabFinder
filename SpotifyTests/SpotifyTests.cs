using Microsoft.VisualStudio.TestTools.UnitTesting;
using TabFinder;
using System;
using System.Threading.Tasks;

namespace TabFinder.Tests
{
    [TestClass()]
    public class SpotifyTests
    {
        [TestMethod()]
        public async Task CheckAuthTest()
        {
            await Spotify.CheckAuth();
        }
    }
}