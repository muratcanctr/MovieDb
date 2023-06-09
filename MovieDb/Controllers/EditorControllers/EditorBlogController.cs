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

namespace MovieDb.Controllers.EditorControllers
{
    public class EditorBlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IFileUploadService _fileUploadService;

        public EditorBlogController(ApplicationDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _fileUploadService = fileUploadService;
        }

        // GET: EditorBlog
        public async Task<IActionResult> Index()
        {
              return _context.Blogs != null ? 
                          View(await _context.Blogs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Blogs'  is null.");
        }

        // GET: EditorBlog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blogDao = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogDao == null)
            {
                return NotFound();
            }

            return View(blogDao);
        }

        // GET: EditorBlog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EditorBlog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( BlogDao blogDao, IFormFile bannerFileInput, [FromForm] IFormFile listImageFileInput, List<string> categories)
        {
            if (ModelState.IsValid)
            {
                blogDao.BlogContentId = Guid.NewGuid();
                blogDao.Categories = String.Join(",", categories);
                blogDao.Banner = _fileUploadService.UploadFile(bannerFileInput);
                blogDao.ListImage = _fileUploadService.UploadFile(listImageFileInput);
                _context.Add(blogDao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            return View(blogDao);
        }

        // GET: EditorBlog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blogDao = await _context.Blogs.FindAsync(id);
            if (blogDao == null)
            {
                return NotFound();
            }
            return View(blogDao);
        }

        // POST: EditorBlog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BlogDao blogDao, IFormFile? bannerFileInput, [FromForm] IFormFile? listImageFileInput, List<string>? updatedCategories)
        {
            if (id != blogDao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (updatedCategories != null && updatedCategories.Count > 0 )
                    {
                        blogDao.Categories = String.Join(",", updatedCategories);
                    }
                    if (bannerFileInput != null)
                    {
                        blogDao.Banner = _fileUploadService.UploadFile(bannerFileInput);
                    }
                    if (listImageFileInput != null)
                    {
                        blogDao.ListImage = _fileUploadService.UploadFile(listImageFileInput);
                    }
                    _context.Update(blogDao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogDaoExists(blogDao.Id))
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
            return View(blogDao);
        }

        // GET: EditorBlog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blogs == null)
            {
                return NotFound();
            }

            var blogDao = await _context.Blogs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogDao == null)
            {
                return NotFound();
            }

            return View(blogDao);
        }

        // POST: EditorBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blogs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Blogs'  is null.");
            }
            var blogDao = await _context.Blogs.FindAsync(id);
            if (blogDao != null)
            {
                _context.Blogs.Remove(blogDao);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogDaoExists(int id)
        {
          return (_context.Blogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
