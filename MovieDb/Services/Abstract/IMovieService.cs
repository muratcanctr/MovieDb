using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
    public interface IMovieService
    {
        Task<MovieDao> GetById(int? id);
        Task<PaginatedListViewModel<MovieDao>> GetAllMovies(int pageNumber, int pageSize);
        Task<List<ActorDao>> GetActors();
    }
}
