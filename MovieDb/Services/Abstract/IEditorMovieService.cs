using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
    public interface IEditorMovieService
    {
        Task<MovieDao> GetById(int? id);
        Task<List<MovieDao>> GetAll();
        Task Add(MovieDao movie);
        Task Update(MovieDao movie);
        Task Delete(MovieDao movie);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
    }
}
