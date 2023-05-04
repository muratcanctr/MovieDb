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
    public class MovieMediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;
        private readonly IFileUploadService _fileUploadService;

        public MovieMediaController(ApplicationDbContext context, IEditorMovieService movieService, IFileUploadService fileUploadService)
        {
            _context = context;
            _movieService = movieService;
            _fileUploadService = fileUploadService;
        }

        // GET: MovieMedia
        public async Task<IActionResult> Index()
        {
              return _context.MovieMedia != null ? 
                          View(await _context.MovieMedia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MovieMedia'  is null.");
        }

        // GET: MovieMedia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieMedia == null)
            {
                return NotFound();
            }

            var movieMediaDao = await _context.MovieMedia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieMediaDao == null)
            {
                return NotFound();
            }

            return View(movieMediaDao);
        }

        // GET: MovieMedia/Create
        public async Task<IActionResult> Create()
        {
            var movieData = await _movieService.GetAll();
            ViewBag.Movies = new SelectList(movieData, "ContentId", "Title");
            return View();
        }

        // POST: MovieMedia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,MovieContentId,MediaType")] MovieMediaDao movieMediaDao, [FromForm] IFormFile? photoFileInput,string? url)
        {
            if (ModelState.IsValid)
            {
                movieMediaDao.ContentId = Guid.NewGuid();                
                if (photoFileInput!=null)
                {                    
                    movieMediaDao.Url= _fileUploadService.UploadFile(photoFileInput);
                }
                if (!String.IsNullOrEmpty(url))
                {
                    movieMediaDao.Url = url;
                    var ıd = url.Split("/");
                    movieMediaDao.MovieThumbnail = "https://img.youtube.com/vi/" + ıd.Last() + "/0.jpg";
                }
                var movieData = _movieService.GetByContentId(movieMediaDao.MovieContentId.ToString());
                movieMediaDao.MovieName = movieData.Result.Title;
                _context.Add(movieMediaDao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(movieMediaDao);
        }

        // GET: MovieMedia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieMedia == null)
            {
                return NotFound();
            }

            var movieMediaDao = await _context.MovieMedia.FindAsync(id);
            if (movieMediaDao == null)
            {
                return NotFound();
            }
            return View(movieMediaDao);
        }

        // POST: MovieMedia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContentId,MovieContentId,Title,Url,MediaType")] MovieMediaDao movieMediaDao)
        {
            if (id != movieMediaDao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieMediaDao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieMediaDaoExists(movieMediaDao.Id))
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
            return View(movieMediaDao);
        }

        // GET: MovieMedia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieMedia == null)
            {
                return NotFound();
            }

            var movieMediaDao = await _context.MovieMedia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieMediaDao == null)
            {
                return NotFound();
            }

            return View(movieMediaDao);
        }

        // POST: MovieMedia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieMedia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MovieMedia'  is null.");
            }
            var movieMediaDao = await _context.MovieMedia.FindAsync(id);
            if (movieMediaDao != null)
            {
                _context.MovieMedia.Remove(movieMediaDao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieMediaDaoExists(int id)
        {
          return (_context.MovieMedia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
