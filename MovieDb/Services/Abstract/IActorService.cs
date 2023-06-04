using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
	public interface IActorService
	{
        Task<ActorDao> GetById(int? id);
        Task<PaginatedListViewModel<ActorDao>> GetAllActors(int pageNumber, int pageSize);
        Task<List<MovieDao>> GetMovies();
        Task<List<ActorMediaDao>> GetAllActorMedia(Guid? actorId);
    }
}
