using MovieDb.Data.ViewModels;
using MovieDb.Models;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
    public interface IMovieService
    {
        Task<MovieDao> GetById(int? id);
        Task<PaginatedListViewModel<MovieDao>> GetAllMovies(int pageNumber, int pageSize);
        Task<List<ActorDao>> GetActors();
        Task AddReview(MovieReviewsDao movieReviews);
        Task<PaginatedListViewModel<MovieReviewsDao>> GetAllReviews(Guid? movieId, int pageNumber, int pageSize);
        Task<PaginatedListViewModel<MovieDao>> GetFavMovies(ApplicationUser user, int pageNumber);
        Task<List<MovieMediaDao>> GetAllMovieMedia(Guid? movieId);
    }
}
