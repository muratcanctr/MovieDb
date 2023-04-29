using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
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

        public Task Delete(MovieDao movie)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MovieDao>> GetAll()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<MovieDao> GetById(int id)
        {
            return await _context.Movies.FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task Update(MovieDao movie)
        {
           var data = await _context.Movies.FirstOrDefaultAsync(n => n.Id == movie.Id);            

        }
    }
}
