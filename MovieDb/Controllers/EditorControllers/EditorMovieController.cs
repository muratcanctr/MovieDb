using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;
using MovieDb.Services.Concrete;

namespace MovieDb.Controllers.EditorControllers
{
    public class EditorMovieController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;   
        private readonly IEditorActorService _actorService;   
        private readonly IFileUploadService _fileUploadService;

        public EditorMovieController(IEditorMovieService movieService, IFileUploadService fileUploadService, ApplicationDbContext context, IEditorActorService actorService)
        {
            _movieService = movieService;
            _fileUploadService = fileUploadService;
            _context = context;
            _actorService = actorService;
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

        
        public async Task<IActionResult> Details(int? id)
        {
            var movie = await _movieService.GetById(id);
            return View(movie);
        }

        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ContentId", "FullName");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieVM, [FromForm] IFormFile bannerFileInput, [FromForm] IFormFile thumbnailFileInput)
        {
            if (ModelState.IsValid)
            {
                movieVM.movie.ContentId = Guid.NewGuid();
               
                movieVM.movie.Actors = string.Join(",", movieVM.Actors.Select(g => g.ToString()));

                movieVM.movie.Banner = _fileUploadService.UploadFile(bannerFileInput);

                await _movieService.Add(movieVM.movie);
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(movieVM.movie);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ContentId", "FullName");
            var movieVM = new MovieViewModel();
            movieVM.movie = await _movieService.GetById(id);
            return View(movieVM);
        }

        // POST: EditorActor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MovieViewModel movieVM, [FromForm] IFormFile? bannerFileInput)
        {
            if (id != movieVM.movie.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (movieVM.Actors!=null)
                    {
                        movieVM.movie.Actors = string.Join(",", movieVM.Actors.Select(g => g.ToString()));
                    }                    
                    if (bannerFileInput != null)
                    {
                        movieVM.movie.Banner = _fileUploadService.UploadFile(bannerFileInput);
                    }

                    await _movieService.Update(movieVM.movie);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDaoExists(movieVM.movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(movieVM.movie);
        }

        // GET: EditorActor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var actorDao = await _movieService.GetById(id);
            return View(actorDao);
        }

        // POST: EditorActor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Actors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Actors'  is null.");
            }
            var movieDao = await _context.Movies.FindAsync(id);
            if (movieDao != null)
            {
                await _movieService.Delete(movieDao);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDaoExists(int id)
        {
            return (_context.Actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
