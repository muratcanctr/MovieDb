using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class ActorDetailViewModel
    {
        public ActorDao ActorDetails;
        public List<MovieDao> Movies;
        public List<string> PlotKeys;
        public List<ActorMediaDao> ActorMedia;

        public ActorDetailViewModel()
        {
            ActorDetails = new ActorDao();
            Movies = new List<MovieDao>();
            PlotKeys = new List<string>();
            ActorMedia = new List<ActorMediaDao>();
        }
    }
}
