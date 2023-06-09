using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
    public interface IHomepageService
    {
        public List<MovieDao> getHomepageSlider();
        public List<MovieDao> getComingSoonMovies();
        public List<MovieDao> getTopRatedMovies();
        public List<BlogDao> getHomepageBlogs();
    }
}
