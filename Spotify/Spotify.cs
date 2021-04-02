using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace TabFinder
{
    public class Spotify
    {
        private string clientID = "REDACTED"; // TODO to config/env later
        private string clientSecret = "REDACTED";
        private SpotifyClient spotify;

        public Spotify(string accessToken)
        {
            this.spotify = new SpotifyClient(accessToken);
        }
        public async Task CheckAuth()
        {
            FullTrack track = await this.spotify.Tracks.Get("2TYPyMen3VrXo4bljRLQvo");
            Console.WriteLine(track.Name);
        }

        public async Task<List<FullTrack>> GetPlaylistTracks(string playlist)
        {
            List<FullTrack> final = new List<FullTrack>();
            Paging<PlaylistTrack<IPlayableItem>> firstPage = await this.spotify.Playlists.GetItems(playlist);
            await foreach (var item in spotify.Paginate(firstPage))
            {
                if (item.Track is FullTrack track)
                {
                    final.Add(track);
                }
            }
            return final;
        }

        public async Task<List<FullTrack>> GetLibraryTracks()
        {
            List<FullTrack> final = new List<FullTrack>();
            Paging<SavedTrack> firstPage = await this.spotify.Library.GetTracks();
            await foreach (var item in spotify.Paginate(firstPage))
            {
                final.Add(item.Track);
            }
            return final;
        }
    }
}
