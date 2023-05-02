using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class MovieDetailViewModel
    {
        public MovieDao movieDetails;
        public List<ActorDao> actors;

        public MovieDetailViewModel()
        {
            movieDetails =new MovieDao();
            actors = new List<ActorDao>();
        }
    }
}
