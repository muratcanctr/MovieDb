using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDb.Data.Dto;
using MovieDb.Data.ViewModels;
using MovieDb.Models;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;
using MovieDb.Services.Concrete;
using System.Drawing.Printing;
using System.Security.Claims;

namespace MovieDb.Controllers.BlogControllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogsController(IBlogService blogService, UserManager<ApplicationUser> userManager)
        {
            _blogService = blogService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string category ,int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                pageNumber = 1;
            }
            if (pageSize == 0)
            {
                pageSize = 10;
            }
            if (category !=null)
            {
                ViewBag.Category = category;
              return View( await _blogService.GetBlogByCategory(category,pageNumber, pageSize));
            }            
            return View(await _blogService.GetAllBlog(pageNumber, pageSize));
        }
        public async Task<IActionResult> Detail(int id)
        {
            var blogDetail = await _blogService.GetBlogById(id);
            var data = await _blogService.GetBlogComments(blogDetail.BlogContentId);
            
            var blogComments = new List<BlogPostCommentDto>();
            foreach (var item in data)
            {
                var blogComment = new BlogPostCommentDto();
                var user = _userManager.FindByIdAsync(item.userId.ToString());
                blogComment.CreateDate = item.CreateDate;
                blogComment.Comment = item.Comment;
                blogComment.Username =  user.Result.UserName;
                blogComment.ProfilePicture = user.Result.ProfilePicture;
                blogComments.Add(blogComment);
            }

            var model = new BlogViewModel()
            {
                blog = blogDetail,
                comments = blogComments
            };
            return View(model);
        }
        public async Task<IActionResult> AddComment(Guid userId, string blogCId,  string message, string blogId)
        {
            if (userId != Guid.Empty || blogCId != null || message != null || message != "")
            {
                var comment = new BlogCommentDao()
                {
                    CreateDate = DateTime.Now,
                    userId = userId,
                    BlogContentId = Guid.Parse(blogCId),
                    Comment = message
                };

                await _blogService.AddComment(comment);
                

                return RedirectToAction(nameof(Detail), new { id = Int32.Parse(blogId) });
            }

            return RedirectToAction(nameof(Detail));
        }
    }
}
