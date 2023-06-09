using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class EditorActorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorMovieService _movieService;
        private readonly IEditorActorService _editorActorService;
        private readonly IFileUploadService _fileUploadService;

        public EditorActorController(ApplicationDbContext context, IEditorActorService editorActorService, IFileUploadService fileUploadService, IEditorMovieService movieService)
        {
            _context = context;
            _editorActorService = editorActorService;
            _fileUploadService = fileUploadService;
            _movieService = movieService;
        }

        // GET: EditorActor
        public async Task<IActionResult> Index()
        {
            return View(await _editorActorService.GetAll());
        }

        // GET: EditorActor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var actorDao = await _editorActorService.GetById(id);
            return View(actorDao);
        }

        // GET: EditorActor/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ContentId", "FullName");
            ViewBag.Movies = new SelectList(movieDropdownsData.Movies, "ContentId", "Title");
            return View();
        }

        // POST: EditorActor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActorViewModel actorVm, [FromForm] IFormFile bannerFileInput, [FromForm] IFormFile thumbnailFileInput)
        {
            
            if (ModelState.IsValid)
            {
                actorVm.actor.ContentId = Guid.NewGuid();
                actorVm.actor.Banner = _fileUploadService.UploadFile(bannerFileInput);
                actorVm.actor.Thumbnail = _fileUploadService.UploadFile(thumbnailFileInput);
                actorVm.actor.Movies = string.Join(",", actorVm.Movies.Where(x=> x!=null).Select(g => g.ToString()));

                await _editorActorService.Add(actorVm.actor);
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(actorVm.actor);
        }

        // GET: EditorActor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var movieDropdownsData = await _movieService.GetNewMovieDropdownsValues();
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "ContentId", "FullName");
            ViewBag.Movies = new SelectList(movieDropdownsData.Movies, "ContentId", "Title");
            var actorVm = new ActorViewModel();
            actorVm.actor = await _editorActorService.GetById(id);
            return View(actorVm);
        }

        // POST: EditorActor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActorViewModel actorVm, [FromForm] IFormFile? bannerFileInput, [FromForm] IFormFile? thumbnailFileInput)
        {
            if (id != actorVm.actor.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (actorVm.Movies!= null)
                    {
                        actorVm.actor.Movies = string.Join(",", actorVm.Movies.Where(x => x != null).Select(g => g.ToString()));
                    }
                    else
                    {
                        actorVm.actor.Movies = _editorActorService.GetById(id).Result.Movies;
                    }
                    if (thumbnailFileInput != null)
                    {
                        actorVm.actor.Thumbnail = _fileUploadService.UploadFile(thumbnailFileInput);
                    }                  
                    
                    await _editorActorService.Update(actorVm.actor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorDaoExists(actorVm.actor.Id))
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
            return View(actorVm);
        }

        // GET: EditorActor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var actorDao = await _editorActorService.GetById(id);
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
            var actorDao = await _context.Actors.FindAsync(id);
            if (actorDao != null)
            {
                await _editorActorService.Delete(actorDao);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ActorDaoExists(int id)
        {
          return (_context.Actors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
