using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDb.Models;
using MovieDb.Services.Abstract;

namespace MovieDb.Controllers.UserProfileControllers
{
    public class UserProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IFileUploadService  _fileService;
        private readonly IMovieService  _movieService;


        public UserProfileController(UserManager<ApplicationUser> userManager, IFileUploadService fileService, SignInManager<ApplicationUser> signInManager, IMovieService movieService)
        {
            _userManager = userManager;
            _fileService = fileService;
            _signInManager = signInManager;
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public async Task<IActionResult>  ChangeProfileAvatar([FromForm] IFormFile fileInput)
        {
            var user = await _userManager.GetUserAsync(User);
            if (fileInput !=null)
            {
                var path = _fileService.UploadFile(fileInput);
                user.ProfilePicture = path;
                await _userManager.UpdateAsync(user);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> UpdateUser(string username,string firstName,string lastName)
        {
            var data = await _userManager.GetUserAsync(User);
            if (data != null)
            {
                data.FirstName = firstName;
                data.LastName = lastName;
                data.UserName = username;
                await _userManager.UpdateAsync(data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ModelState.AddModelError(string.Empty, "The new password and confirmation password do not match.");
                return RedirectToAction("Index");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await _signInManager.RefreshSignInAsync(user);
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
        public async Task<IActionResult> FavoriteMovies( int pageNumber)
        {
            var user = await _userManager.GetUserAsync(User);
            var data = await _movieService.GetFavMovies(user,pageNumber);
            return View(data);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


    }
}
