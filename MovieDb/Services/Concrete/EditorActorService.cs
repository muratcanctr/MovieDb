using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
    public class EditorActorService : IEditorActorService
    {
        private readonly ApplicationDbContext _context;

        public EditorActorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ActorDao actor)
        {
            _context.Add(actor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ActorDao actor)
        {
            if (actor != null)
            {
                _context.Actors.Remove(actor);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ActorDao>> GetAll()
        {
            return _context.Actors != null ? await _context.Actors.ToListAsync() : null;
                          
        }

        public async Task<ActorDao> GetByContentId(Guid? contentId)
        {
            if (_context.Actors == null)
            {
                return null;
            }

            var actorDao = await _context.Actors
                .FirstOrDefaultAsync(m => m.ContentId == contentId);
            if (actorDao == null)
            {
                return null;
            }
            return actorDao;
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

        public async Task Update(ActorDao actor)
        { 
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();         
        }
    }
}
