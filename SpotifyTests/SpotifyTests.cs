using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpotifyAPI.Web;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TabFinder.Tests
{
    [TestClass()]
    public class SpotifyTests
    {
        // Replace at start of each test session, will expire
        string accessToken = "";
        Spotify spotify;

        [TestInitialize]
        public void Init()
        {
            spotify = new Spotify(accessToken);
        }

        [TestMethod()]
        public async Task CheckAuthTest()
        {
            await spotify.CheckAuth();
        }

        [TestMethod()]
        public async Task GetPlaylistTracksTest()
        {
            string playlist = "6CTQqiCeDeJVmpfoUhLug3";
            List<BasicSong> trackStrings = await spotify.GetPlaylistTracks(playlist);
            Assert.AreEqual(2, trackStrings.Count);
        }

        [TestMethod()]
        public async Task GetLibraryTracksTest()
        {
            List<BasicSong> trackStrings = await spotify.GetLibraryTracks();
            Assert.IsTrue(trackStrings.Count > 1000);
        }
    }
}