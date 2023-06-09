namespace MovieDb.Models.Dao
{
	public class BlogCommentDao
	{
		public int Id { get; set; }
		public Guid BlogContentId { get; set; }
		public Guid userId { get; set; }
		public string Comment { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
