using Microsoft.AspNetCore.Mvc;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Controllers.MoviesControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IEditorActorService _actorService;

        public MovieController(IMovieService movieService, IEditorActorService actorService)
        {
            _movieService = movieService;
            _actorService = actorService;
        }

        public async Task<IActionResult> Index(int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 1;
            }            
            return  View(await _movieService.GetAllMovies(pageNumber, pageSize));
        }
        public async Task<IActionResult> Details(int id)
        {
            
            var data = await _movieService.GetById(id);
            var movie = new MovieDetailViewModel
            {
                movieDetails = data,
                actors = new List<ActorDao>()
            };
            movie.movieDetails = data;
            var actorIds = data.Actors.Split(",");
            foreach (var item in actorIds)
            {                
                var data2 = await _actorService.GetByContentId(Guid.Parse(item));
                movie.actors.Add(data2);
            }
            return  View(movie);
        }
    }
}
