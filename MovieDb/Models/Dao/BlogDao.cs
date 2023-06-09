namespace MovieDb.Models.Dao
{
    public class BlogDao
    {
        public int Id { get; set; }
        public Guid? BlogContentId { get; set; }
        public string Title { get; set; }
        public string? Banner { get; set; }
        public string? ListImage { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Categories { get; set; }
        public string? Paragraph1 { get; set; }
        public string? Paragraph2 { get; set; }
        public string? Paragraph3 { get; set; }
        public string? Paragraph4 { get; set; }
        public string? Paragraph5 { get; set; }
        public string Tags { get; set; }

    }
}
