using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
    public interface IEditorActorService
    {
        Task<ActorDao> GetByContentId(Guid? contentId);
        Task<ActorDao> GetById(int? id);
        Task<List<ActorDao>> GetAll();
        Task Add(ActorDao actor);
        Task Update(ActorDao actor);
        Task Delete(ActorDao actor);        
    }
}
