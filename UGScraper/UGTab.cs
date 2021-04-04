namespace TabFinder
{
    public class UGTab
    {
        public string artist { get; }
        public string title { get; }
        public int? rating { get; }
        public int? numRatings { get; }
        public string tab { get; }
        public UGTab(string artist, string title, int? rating, int? numRatings, string tab)
        {
            this.artist = artist;
            this.title = title;
            this.rating = rating;
            this.numRatings = numRatings;
            this.tab = tab;
        }
    }
}
