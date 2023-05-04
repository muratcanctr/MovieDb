namespace MovieDb.Models.Dao
{
	public class MovieMediaDao
	{
		public int Id { get; set; }
		public Guid ContentId { get; set; }
		public Guid MovieContentId { get; set; }
		public string? MovieName { get; set; }
		public string? MovieThumbnail { get; set; }
		public string Title { get; set; }
		public string? Url{ get; set; }
		public string MediaType{ get; set; }
	}
}
