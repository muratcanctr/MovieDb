using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieDb.Data.ViewModels;
using MovieDb.Models;
using MovieDb.Models.Dao;
using MovieDb.Services.Abstract;
using MovieDb.Services.Concrete;

namespace MovieDb.Controllers.ActorControllers
{
	public class ActorController : Controller
	{
        private readonly IActorService _actorService;
        private readonly IEditorActorService _editorActorService;
        private readonly IEditorMovieService _editorMovieService;
        private readonly UserManager<ApplicationUser> _userManager;

		public ActorController(IActorService actorService, IEditorActorService editorActorService, IEditorMovieService editorMovieService, UserManager<ApplicationUser> userManager)
		{
			_actorService = actorService;
			_editorActorService = editorActorService;
			_editorMovieService = editorMovieService;
			_userManager = userManager;
		}
		
        public async Task<IActionResult> Details(int id)
        {

            var data = await _actorService.GetById(id);
            if (data != null)
            {
                var actor = new ActorDetailViewModel
                {
                    ActorDetails = data,
                    Movies = new List<MovieDao>()
                };
                actor.ActorDetails = data;

                var actorIds = data.Movies.Split(",");
                foreach (var item in actorIds)
                {
                    var data2 = await _editorMovieService.GetByContentId(item);
                    actor.Movies.Add(data2);
                }

                var plotKeys = actor.ActorDetails.PlotKeywords.Split(",");
                foreach (var item in plotKeys)
                {
                    actor.PlotKeys.Add(item);
                }
                
                actor.ActorMedia = await _actorService.GetAllActorMedia(actor.ActorDetails.ContentId);
                return View(actor);
            }
            return View();
        }
        
    }
}
