namespace MovieDb.Models.Dao
{
	public class MovieReviewsDao
	{
		public int Id { get; set; }
		public Guid movieContentId { get; set; }
		public Guid userId { get; set; }
		public string Title { get; set; }
		public string Review { get; set; }
		public DateTime CreateDate { get; set; }
		public float MovieRating { get; set; }
	}
}
