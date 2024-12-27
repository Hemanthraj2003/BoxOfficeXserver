using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class ShowModel
    {
        [Key]
        public int showID { get; set; }
        public int movieID { get; set; }
        public int theaterID { get; set; }
        public string seats { get; set; }
        public DateTime Date { get; set; }

        public string slot { get; set; }
        public int cost { get; set; }
    }
}
