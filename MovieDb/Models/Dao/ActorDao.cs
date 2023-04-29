
using System.ComponentModel.DataAnnotations;

namespace MovieDb.Models.Dao
{
    public class ActorDao
    {
            public int Id { get; set; }
            public Guid ContentId { get; set; }
            public string FullName { get; set; }
            public string Banner { get; set; }
            public string Thumbnail { get; set; }
            public string PlotKeywords { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Country { get; set; }
            public int Height { get; set; }
            public string Movies { get; set; }
    }
}
