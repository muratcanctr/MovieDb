using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
    public class HomepageService : IHomepageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;
        private readonly IEditorActorService _actorService;

        public HomepageService(ApplicationDbContext context, IEditorMovieService movieService, IEditorActorService actorService)
        {
            _context = context;
            _movieService = movieService;
            _actorService = actorService;
        }

        public List<MovieDao> getComingSoonMovies()
        {
            var today = DateTime.Today;
            var endDate = today.AddDays(14);
            var data = _context.Movies.Where(x => x.ReleaseDate >= today && x.ReleaseDate < endDate).OrderBy(t=>t.ReleaseDate).Take(12).ToList();     
            return data;
        }

        public List<BlogDao> getHomepageBlogs()
        {
            var data = _context.Blogs.OrderByDescending(t => t.CreateDate).Take(5).ToList();
            return data;
        }

        public List<MovieDao> getHomepageSlider()
        {
            var movieIds = _context.HomepageSlider.FirstOrDefault().movieId.Split(",");
            var model = new List<MovieDao>();
            foreach (var item in movieIds)
            {
                var movie = _movieService.GetByContentId(item).Result;
                model.Add(movie);
            }
            return (model);
            
        }

        public List<MovieDao> getTopRatedMovies()
        {
            var data = _context.Movies.OrderByDescending(t => t.Rating).Take(12).ToList();
            return data;
        }
    }
}
