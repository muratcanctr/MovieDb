using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;

namespace MovieDb.Services.Abstract
{
	public interface IBlogService
	{
        Task<PaginatedListViewModel<BlogDao>> GetAllBlog(int pageNumber, int pageSize);
        Task<PaginatedListViewModel<BlogDao>> GetBlogByCategory(string category,int pageNumber, int pageSize);
        Task<BlogDao> GetBlogById(int id);
        Task AddComment(BlogCommentDao blogComment);
        Task<List<BlogCommentDao>> GetBlogComments(Guid? blogId);
    }
}
