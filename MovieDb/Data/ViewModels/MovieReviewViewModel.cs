using MovieDb.Models;
using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
	public class MovieReviewViewModel
	{
		public List<MovieReviewsDao> movieReviews;

		public MovieReviewViewModel()
		{
			this.movieReviews = new List<MovieReviewsDao>();
		}
	}
}
