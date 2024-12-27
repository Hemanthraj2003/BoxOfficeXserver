using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class TheaterModel
    {
        [Key]
        public int theaterId { get; set; }


        public string userName { get; set; }
        public string password { get; set; }
        public string theaterName { get; set; }
        public string address { get; set; }


    }
}
