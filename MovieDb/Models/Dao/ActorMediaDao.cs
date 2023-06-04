namespace MovieDb.Models.Dao
{
	public class ActorMediaDao
	{
		public int Id { get; set; }
		public Guid ContentId { get; set; }
		public Guid ActorContentId { get; set; }
		public string? ActorName { get; set; }
		public string? ActorThumbnail { get; set; }
		public string Title { get; set; }
		public string? Url{ get; set; }
		public string MediaType{ get; set; }
	}
}
