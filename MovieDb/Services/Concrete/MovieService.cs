using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ActorDao>> GetActors()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedListViewModel<MovieDao>> GetAllMovies(int pageNumber, int pageSize)
        {
            var data = _context.Movies.AsQueryable();

            var movies = await _context.Movies
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int count = await _context.Movies.CountAsync();

            var model = new PaginatedListViewModel<MovieDao>(movies, count, pageNumber, pageSize);
            
            return model;

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
    }
}
