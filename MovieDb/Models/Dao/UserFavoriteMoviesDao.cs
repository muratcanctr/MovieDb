namespace MovieDb.Models.Dao
{
	public class UserFavoriteMoviesDao
	{
		public int Id { get; set; }
		public Guid userId { get; set; }
		public Guid movieContentId { get; set; }
	}
}
