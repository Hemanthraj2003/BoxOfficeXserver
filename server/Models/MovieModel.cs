using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterURL { get; set; }
        public string ratings { get; set; }
    }
}
