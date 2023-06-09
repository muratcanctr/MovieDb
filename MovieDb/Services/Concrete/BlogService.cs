using Microsoft.EntityFrameworkCore;
using MovieDb.Data;
using MovieDb.Data.ViewModels;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;

namespace MovieDb.Services.Concrete
{
	public class BlogService : IBlogService
	{
        private readonly ApplicationDbContext _context;

		public BlogService(ApplicationDbContext context)
		{
			_context = context;
		}

        public async Task AddComment(BlogCommentDao blogComment)
        {
            await _context.BlogPostComments.AddAsync(blogComment);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedListViewModel<BlogDao>> GetAllBlog(int pageNumber, int pageSize)
		{
            var data = _context.Blogs.AsQueryable();

            var blogs = await _context.Blogs
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int count = await _context.Blogs.CountAsync();
			foreach (var item in blogs)
			{
				if (item.Paragraph1.Length>50)
				{
					item.Paragraph1 = item.Paragraph1.Substring(0, 50) + " ...";
				}
			}
            var model = new PaginatedListViewModel<BlogDao>(blogs, count, pageNumber, pageSize);

            return model;
        }

		public async Task<PaginatedListViewModel<BlogDao>> GetBlogByCategory(string category, int pageNumber, int pageSize)
		{
            var data = _context.Blogs.AsQueryable();

            var blogs = await _context.Blogs
            .Where(x=> x.Categories.Contains(category))
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

            int count = await _context.Blogs.CountAsync();
            foreach (var item in blogs)
            {
                if (item.Paragraph1.Length > 50)
                {
                    item.Paragraph1 = item.Paragraph1.Substring(0, 50) + " ...";
                }
            }
            var model = new PaginatedListViewModel<BlogDao>(blogs, count, pageNumber, pageSize);

            return model;
        }

        public async Task<BlogDao> GetBlogById(int id)
        {
            BlogDao blog = await _context.Blogs.Where(x => x.Id == id).FirstOrDefaultAsync();
            return blog;
        }

        public async Task<List<BlogCommentDao>> GetBlogComments(Guid? blogId)
        {
            var comments = await _context.BlogPostComments
            .Where(x => x.BlogContentId == blogId)
            .OrderBy(x => x.CreateDate)
            .ToListAsync();
            return comments;
        }
    }
}
