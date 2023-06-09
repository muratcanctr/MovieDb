using MovieDb.Data.Dto;
using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
	public class BlogViewModel
	{
		public BlogDao blog;
		public List<BlogPostCommentDto> comments;

		public BlogViewModel()
		{
		}

		
	}
}
