using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
	public class ActorService : IActorService
	{
        private readonly ApplicationDbContext _context;

		public ActorService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<ActorMediaDao>> GetAllActorMedia(Guid? actorId)
		{
            var media = await _context.ActorMedia
            .Where(x => x.ActorContentId == actorId)
            .ToListAsync();
            return media;
        }

		public async Task<PaginatedListViewModel<ActorDao>> GetAllActors(int pageNumber, int pageSize)
		{
            var data = _context.Actors.AsQueryable();

            var actors = await _context.Actors
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int count = await _context.Actors.CountAsync();

            var model = new PaginatedListViewModel<ActorDao>(actors, count, pageNumber, pageSize);

            return model;
        }

		public async Task<ActorDao> GetById(int? id)
		{
            if (id == null || _context.Actors == null)
            {
                return null;
            }

            var actorDao = await _context.Actors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (actorDao == null)
            {
                return null;
            }
            return actorDao;
        }

		public Task<List<MovieDao>> GetMovies()
		{
			throw new NotImplementedException();
		}
	}
}
