using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class HomepageViewModel
    {
        public List<MovieDao> MainSlider;
        public List<MovieDao> PopularSlider;
        public List<MovieDao> ComingSoonSlider;
        public List<MovieDao> TopRatedSlider;
        public List<ActorDao> SpotlightActor;
        public List<BlogDao> HomepageBlogs;
    }
}
