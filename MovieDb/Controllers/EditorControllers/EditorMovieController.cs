using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;
using MovieDb.Services.Concrete;

namespace MovieDb.Controllers.EditorControllers
{
    public class EditorMovieController : Controller
    {
        private readonly IEditorMovieService _movieService;   
        private readonly IFileUploadService _fileUploadService;

        public EditorMovieController(IEditorMovieService movieService, IFileUploadService fileUploadService)
        {
            _movieService = movieService;
            _fileUploadService = fileUploadService;
        }

        public async Task<IActionResult> Index()
        {
            var model= await _movieService.GetAll();
            if (model == null)
            {
                return View();
            }
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Summary,PlotKeywords,MMPARating,RunTime,ReleaseDate")] MovieDao movieDao, [FromForm] IFormFile bannerFileInput, [FromForm] IFormFile thumbnailFileInput)
        {
            if (ModelState.IsValid)
            {
                movieDao.ContentId = Guid.NewGuid();

                movieDao.Banner = _fileUploadService.UploadFile(bannerFileInput);
                movieDao.Thumbnail = _fileUploadService.UploadFile(thumbnailFileInput);

                await _movieService.Add(movieDao);
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(movieDao);
        }
    }
}
