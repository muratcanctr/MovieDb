using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Models.Dao;

namespace MovieDb.Controllers.EditorControllers
{
    public class MovieDaosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieDaosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MovieDaos
        public async Task<IActionResult> Index()
        {
              return _context.Movies != null ? 
                          View(await _context.Movies.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
        }

        // GET: MovieDaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDao = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDao == null)
            {
                return NotFound();
            }

            return View(movieDao);
        }

        // GET: MovieDaos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieDaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContentId,Title,Banner,Summary,Thumbnail,PlotKeywords,MMPARating,RunTime,ReleaseDate,Actors")] MovieDao movieDao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieDao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieDao);
        }

        // GET: MovieDaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDao = await _context.Movies.FindAsync(id);
            if (movieDao == null)
            {
                return NotFound();
            }
            return View(movieDao);
        }

        // POST: MovieDaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContentId,Title,Banner,Summary,Thumbnail,PlotKeywords,MMPARating,RunTime,ReleaseDate,Actors")] MovieDao movieDao)
        {
            if (id != movieDao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieDao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieDaoExists(movieDao.Id))
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
            return View(movieDao);
        }

        // GET: MovieDaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            var movieDao = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDao == null)
            {
                return NotFound();
            }

            return View(movieDao);
        }

        // POST: MovieDaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Movies'  is null.");
            }
            var movieDao = await _context.Movies.FindAsync(id);
            if (movieDao != null)
            {
                _context.Movies.Remove(movieDao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieDaoExists(int id)
        {
          return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
