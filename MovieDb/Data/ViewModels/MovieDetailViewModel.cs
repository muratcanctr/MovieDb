using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class MovieDetailViewModel
    {
        public MovieDao movieDetails;
        public List<ActorDao> actors;
        public List<string> PlotKeys;
        public List<string> Genres;
        public MovieReviewViewModel MovieReviews;
        public List<MovieMediaDao> MovieMedia;

        public MovieDetailViewModel()
        {
            movieDetails = new MovieDao();
            actors = new List<ActorDao>();
            PlotKeys = new List<string>();
            MovieReviews =new MovieReviewViewModel();
            MovieMedia = new List<MovieMediaDao>();
            Genres = new List<string>();
        }
    }
}
