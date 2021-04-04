namespace TabFinder
{
    public class BasicSong
    {
        public string artist { get; }
        public string title { get; }
        public string album { get; }
        public string searchString { get; }

        public BasicSong(string artist, string title, string album)
        {
            this.artist = artist;
            this.title = title;
            this.album = album;
            this.searchString = System.Web.HttpUtility.UrlEncode($"{this.artist} {this.title}");
        }
    }
}
