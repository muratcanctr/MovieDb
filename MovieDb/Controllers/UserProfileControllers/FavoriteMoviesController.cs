using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDb.Data;
using MovieDb.Models;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Controllers.UserProfileControllers
{
	public class FavoriteMoviesController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMovieService _movieService;

		public FavoriteMoviesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMovieService movieService)
		{
			_context = context;
			_userManager = userManager;
			_movieService = movieService;
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
            return View(await _movieService.GetAllMovies(pageNumber, pageSize));
        }

        public IActionResult AddFav(string movieCId, string userId)
		{			
			if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(movieCId))
			{
				var checkData = _context.FavoriteMoviesDaos.Where(x => x.userId == Guid.Parse(userId) && x.movieContentId == Guid.Parse(movieCId));
				if (checkData.Any())
				{
                   return RedirectToAction("Index", "Movies");
                }
				var data = new UserFavoriteMoviesDao()
				{
					userId = Guid.Parse(userId),
					movieContentId = Guid.Parse(movieCId)
				};
				_context.FavoriteMoviesDaos.Add(data);
				_context.SaveChanges();
                return RedirectToAction("Index", "Movie");
			}
			return View();
		}

	}
}
