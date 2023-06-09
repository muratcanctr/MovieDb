using Microsoft.AspNetCore.Mvc;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;
using System.Diagnostics;

namespace MovieDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomepageService _homepageService;


        public HomeController(ILogger<HomeController> logger, IHomepageService homepageService)
        {
            _logger = logger;
            _homepageService = homepageService;
        }

        public IActionResult Index()
        {
            var model = new HomepageViewModel();
            model.MainSlider = _homepageService.getHomepageSlider();
            model.ComingSoonSlider = _homepageService.getComingSoonMovies();
            model.TopRatedSlider = _homepageService.getTopRatedMovies();
            model.HomepageBlogs = _homepageService.getHomepageBlogs();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}