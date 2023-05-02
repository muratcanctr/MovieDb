using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
    public class EditorMovieService : IEditorMovieService
    {
        private readonly ApplicationDbContext _context;

        public EditorMovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(MovieDao movie)
        {
            
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(MovieDao movie)
        {
            if (movie != null)
            {
               _context.Movies.Remove(movie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovieDao>> GetAll()
        {
            return  _context.Movies != null ? await _context.Movies.ToListAsync() : null;

        }

        public async Task<MovieDao> GetById(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return null;
            }

            var movieDao = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieDao == null)
            {
                return null;
            }
            return movieDao;
        }

        public async Task Update(MovieDao movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }
        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
    }
}
