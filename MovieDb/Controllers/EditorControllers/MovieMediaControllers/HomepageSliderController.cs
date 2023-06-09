using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Controllers.EditorControllers.MovieMediaControllers
{
    public class HomepageSliderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;

        public HomepageSliderController(ApplicationDbContext context, IEditorMovieService movieService)
        {
            _context = context;
            _movieService = movieService;
        }

        // GET: HomepageSlider
        public async Task<IActionResult> Index()
        {
            var datax = _context.HomepageSlider.FirstOrDefault();

            if (datax == null)
            {
                return View();
            }
            var movieContentIds = datax.movieId.Split(",");
            var movies = new List<MovieDao>();
            foreach (var item in movieContentIds)
            {
                var data = _movieService.GetByContentId(item);
                ViewBag.Movies = ViewBag.Movies + "," + data.Result.Title;
            }
            
            return _context.HomepageSlider != null ? 
                          View(await _context.HomepageSlider.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.HomepageSlider'  is null.");
        }

        // GET: HomepageSlider/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HomepageSlider == null)
            {
                return NotFound();
            }

            var homepageSliderDao = await _context.HomepageSlider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepageSliderDao == null)
            {
                return NotFound();
            }

            return View(homepageSliderDao);
        }

        // GET: HomepageSlider/Create
        public IActionResult Create()
        {
            var data = _movieService.GetNewMovieDropdownsValues();
            var movies = data.Result.Movies;
            return View(movies);
        }

        // POST: HomepageSlider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string selectedMovies)
        {
            
            string cleanedContentIds = selectedMovies.Replace("[", "").Replace("]", "").Replace("\"", "");
            var model = new HomepageSliderDao();
            model.movieId = cleanedContentIds;
            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: HomepageSlider/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HomepageSlider == null)
            {
                return NotFound();
            }

            var homepageSliderDao = await _context.HomepageSlider.FindAsync(id);
            if (homepageSliderDao == null)
            {
                return NotFound();
            }
            var data = _movieService.GetNewMovieDropdownsValues();
            var movies = data.Result.Movies;
            ViewBag.Id = id;
            return View(movies);
        }

        // POST: HomepageSlider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,string selectedMovies)
        {
            string cleanedContentIds = selectedMovies.Replace("[", "").Replace("]", "").Replace("\"", "");
            var model = new HomepageSliderDao();
            model.movieId = cleanedContentIds;
            model.Id = id;
            _context.Update(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: HomepageSlider/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HomepageSlider == null)
            {
                return NotFound();
            }

            var homepageSliderDao = await _context.HomepageSlider
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homepageSliderDao == null)
            {
                return NotFound();
            }

            return View(homepageSliderDao);
        }

        // POST: HomepageSlider/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HomepageSlider == null)
            {
                return Problem("Entity set 'ApplicationDbContext.HomepageSlider'  is null.");
            }
            var homepageSliderDao = await _context.HomepageSlider.FindAsync(id);
            if (homepageSliderDao != null)
            {
                _context.HomepageSlider.Remove(homepageSliderDao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomepageSliderDaoExists(int id)
        {
          return (_context.HomepageSlider?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
