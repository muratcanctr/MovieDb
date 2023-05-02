namespace MovieDb.Models.Dao
{
    public class MovieDao
    {
        public int Id { get; set; }
        public Guid? ContentId { get; set; }
        public string Title { get; set; }
        public string? Banner { get; set; }
        public string Summary { get; set; }
        public string? Trailer { get; set; }
        public string PlotKeywords { get; set; }
        public string MMPARating { get; set; }
        public float Rating { get; set; }
        public int RunTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Actors { get; set; }
    }
}
