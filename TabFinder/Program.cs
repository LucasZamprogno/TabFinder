using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TabFinder
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("requires auth token and playlist uri");
                return;
            }
            Spotify spotify = new Spotify(args[0]);
            List<BasicSong> tracks = await spotify.GetPlaylistTracks(args[1]);
            UGScraper scraper = new UGScraper();
            List<UGTab> tabs = scraper.GetAllTabs(tracks, UGType.Bass);
            foreach (UGTab tab in tabs)
            {
            }
        }
    }
}
