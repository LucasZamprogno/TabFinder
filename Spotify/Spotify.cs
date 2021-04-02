using System;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace TabFinder
{
    public class Spotify
    {
        private string clientID = "";
        public static async Task CheckAuth()
        {
            var spotify = new SpotifyClient("BQDZ1lK5LS7fEUm-NbjrVZ4_7iyavjlVJOERgm27S1uAxzLzVCmoKysVMzlae2du5SIo6N1PFuehcIV_MWPjbua0O993GHv-NXKErtqRgVNYF8ZvUsSvCocgAvptGTEV_IHD-m3pb5td1Emk5OOiOTVuqTsWOt9XFk8NZxDsh6Qi-uGZ");
            Console.WriteLine("Spotify");
            var track = await spotify.Tracks.Get("1s6ux0lNiTziSrd7iUAADH");
            Console.WriteLine(track.Name);
        }
    }
}
