using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class MovieViewModel
    {
        public MovieDao movie { get; set; }
        public List<Guid>? Actors { get; set; }
    }
}
