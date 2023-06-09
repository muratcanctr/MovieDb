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
    public class ActorMediaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;
        private readonly IEditorActorService _actorService;
        private readonly IFileUploadService _fileUploadService;

        public ActorMediaController(ApplicationDbContext context, IEditorMovieService movieService, IFileUploadService fileUploadService, IEditorActorService actorService)
        {
            _context = context;
            _movieService = movieService;
            _fileUploadService = fileUploadService;
            _actorService = actorService;
        }

        // GET: MovieMedia
        public async Task<IActionResult> Index()
        {
              return _context.ActorMedia != null ? 
                          View(await _context.ActorMedia.ToListAsync()) :
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
            var actors = await _actorService.GetAll();
            ViewBag.Actors = new SelectList(actors, "ContentId", "FullName");
            return View();
        }

        // POST: MovieMedia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorMediaDao ActorMediaDao, [FromForm] IFormFile? photoFileInput,string? url)
        {
            if (ModelState.IsValid)
            {
                ActorMediaDao.ContentId = Guid.NewGuid();                
                if (photoFileInput!=null)
                {
                    ActorMediaDao.Url= _fileUploadService.UploadFile(photoFileInput);
                }
                if (!String.IsNullOrEmpty(url))
                {
                    ActorMediaDao.Url = url;
                    var ıd = url.Split("/");
                    ActorMediaDao.ActorThumbnail = "https://img.youtube.com/vi/" + ıd.Last() + "/0.jpg";
                }
                var movieData = _actorService.GetByContentId(ActorMediaDao.ActorContentId);
                ActorMediaDao.ActorName = movieData.Result.FullName;
                _context.Add(ActorMediaDao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(ActorMediaDao);
        }

        // GET: MovieMedia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ActorMedia == null)
            {
                return NotFound();
            }

            var movieMediaDao = await _context.ActorMedia.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, ActorMediaDao ActorMediaDao)
        {
            if (id != ActorMediaDao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ActorMediaDao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieMediaDaoExists(ActorMediaDao.Id))
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
            return View(ActorMediaDao);
        }

        // GET: MovieMedia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ActorMedia == null)
            {
                return NotFound();
            }

            var movieMediaDao = await _context.ActorMedia
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
            var actorMediaDao = await _context.ActorMedia.FindAsync(id);
            if (actorMediaDao != null)
            {
                _context.ActorMedia.Remove(actorMediaDao);
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
