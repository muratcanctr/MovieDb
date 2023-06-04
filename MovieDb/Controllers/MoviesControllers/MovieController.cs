using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDb.Data.ViewModels;
using MovieDb.Migrations;
using MovieDb.Models;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Controllers.MoviesControllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IEditorActorService _actorService;
        private readonly IEditorMovieService _editorMovieService;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieController(IMovieService movieService, IEditorActorService actorService, IEditorMovieService editorMovieService, UserManager<ApplicationUser> userManager)
        {
            _movieService = movieService;
            _actorService = actorService;
            _editorMovieService = editorMovieService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 10;
            }            
            return  View(await _movieService.GetAllMovies(pageNumber, pageSize));
        }
        public async Task<IActionResult> Details(int id)
        {
            
            var data = await _movieService.GetById(id);
            if (data != null)
            {
                var movie = new MovieDetailViewModel
            {
                movieDetails = data,
                actors = new List<ActorDao>(),
                MovieReviews = new MovieReviewViewModel()
            };
            movie.movieDetails = data;
            
                var actorIds = data.Actors.Split(",");
                foreach (var item in actorIds)
                {
                    var data2 = await _actorService.GetByContentId(Guid.Parse(item));
                    movie.actors.Add(data2);
                }
                       
            var plotKeys = movie.movieDetails.PlotKeywords.Split(",");
            foreach (var item in plotKeys)
            {
                movie.PlotKeys.Add(item);
            }
            var genres = movie.movieDetails.Genres.Split(",");
            foreach (var item in genres)
            {
                movie.Genres.Add(item);
            }
            var allReviews = _movieService.GetAllReviews(movie.movieDetails.ContentId, 1, 5);
            foreach (var item in allReviews.Result.Items)
            {
                movie.MovieReviews.movieReviews.Add(item);
            }
                movie.MovieMedia = await _movieService.GetAllMovieMedia(movie.movieDetails.ContentId);
            return  View(movie);
            }
            return View();
        }
        public async Task<IActionResult> AddReview(Guid userId,string movieCId, string Title,int MovieRating, string message,string movieId)
        {
            if (userId != Guid.Empty || movieCId != null || Title != null|| MovieRating != 0||message != null || Title!=""||message!="" )
            {
                var movieReview = new MovieReviewsDao()
                {
                    CreateDate = DateTime.Now,
                    userId = userId,
                    movieContentId = Guid.Parse(movieCId),
                    Title = Title,
                    MovieRating = MovieRating,
                    Review = message
                };
                
                await _movieService.AddReview(movieReview);
                var movie = new MovieDao();
                movie = await _movieService.GetById(Int32.Parse(movieId));
                if (movie != null)
                {
                    var allReviews = _movieService.GetAllReviews(movieReview.movieContentId,1,10);
                    var newRating = ((movie.Rating * allReviews.Result.Count)+MovieRating)/ (allReviews.Result.Count+1);
                    movie.Rating = newRating;
                    await _editorMovieService.Update(movie);
                }

                return RedirectToAction(nameof(Details), new {id=Int32.Parse(movieId)});
            }            
            
            return RedirectToAction(nameof(Details));
        }
        public async Task<IActionResult> AllReviews(int id,int pageNumber)
        {
            if (id != 0)
            {
                var data = await _movieService.GetById(id);
                var movie = new MovieDetailViewModel
                {
                    movieDetails = data,
                    actors = new List<ActorDao>(),
                    MovieReviews = new MovieReviewViewModel()
                };
                movie.movieDetails = data;
                ViewBag.Title = data.Title;
                ViewBag.Trailer = data.Trailer;
                ViewBag.Banner = data.Banner;
                ViewBag.ReleaseDate = data.ReleaseDate;
                var allReviews = await _movieService.GetAllReviews(movie.movieDetails.ContentId, pageNumber, 10);
                return View(allReviews);
            }                        
            return View();
        }
    }
}
