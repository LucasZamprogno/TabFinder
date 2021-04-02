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

        public async Task<List<BasicSong>> GetPlaylistTracks(string playlist)
        {
            List<BasicSong> final = new List<BasicSong>();
            Paging<PlaylistTrack<IPlayableItem>> firstPage = await this.spotify.Playlists.GetItems(playlist);
            await foreach (var item in spotify.Paginate(firstPage))
            {
                if (item.Track is FullTrack track)
                {
                    final.Add(new BasicSong(track.Artists[0].Name, track.Name, track.Album.Name));
                }
            }
            return final;
        }

        public async Task<List<BasicSong>> GetLibraryTracks()
        {
            List<BasicSong> final = new List<BasicSong>();
            Paging<SavedTrack> firstPage = await this.spotify.Library.GetTracks();
            await foreach (var item in spotify.Paginate(firstPage))
            {
                final.Add(new BasicSong(item.Track.Artists[0].Name, item.Track.Name, item.Track.Album.Name));
            }
            return final;
        }
    }
}
