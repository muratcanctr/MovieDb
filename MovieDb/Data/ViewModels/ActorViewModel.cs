using MovieDb.Models.Dao;

namespace MovieDb.Data.ViewModels
{
    public class ActorViewModel
    {
        public ActorDao actor { get; set; }
        public List<string>? Movies { get; set; }
    }
}
