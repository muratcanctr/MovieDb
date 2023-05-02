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
using MovieDb.Services.Concrete;

namespace MovieDb.Controllers.EditorControllers
{
    public class EditorActorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IEditorActorService _editorActorService;
        private readonly IFileUploadService _fileUploadService;

        public EditorActorController(ApplicationDbContext context, IEditorActorService editorActorService, IFileUploadService fileUploadService)
        {
            _context = context;
            _editorActorService = editorActorService;
            _fileUploadService = fileUploadService;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: EditorActor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FullName,PlotKeywords,DateOfBirth,Country,Height")] ActorDao actorDao,[FromForm] IFormFile bannerFileInput, [FromForm] IFormFile thumbnailFileInput)
        {
            if (ModelState.IsValid)
            {
                actorDao.ContentId = Guid.NewGuid();
                actorDao.Banner = _fileUploadService.UploadFile(bannerFileInput);
                actorDao.Thumbnail = _fileUploadService.UploadFile(thumbnailFileInput);

                await _editorActorService.Add(actorDao);
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(actorDao);
        }

        // GET: EditorActor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var actorDao =await _editorActorService.GetById(id);
            return View(actorDao);
        }

        // POST: EditorActor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Banner,Thumbnail,PlotKeywords,DateOfBirth,Country,Height,Movies")] ActorDao actorDao, [FromForm] IFormFile? bannerFileInput, [FromForm] IFormFile? thumbnailFileInput)
        {
            if (id != actorDao.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    if (bannerFileInput != null)
                    {
                        actorDao.Banner = _fileUploadService.UploadFile(bannerFileInput);
                    }
                    if (thumbnailFileInput != null)
                    {
                        actorDao.Thumbnail = _fileUploadService.UploadFile(thumbnailFileInput);
                    }                  
                    
                    await _editorActorService.Update(actorDao);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorDaoExists(actorDao.Id))
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
            return View(actorDao);
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
