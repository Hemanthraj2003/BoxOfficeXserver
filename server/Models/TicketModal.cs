using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class TicketModal
    {
        [Key]
        public int ticketID { get; set; }
        public int movieID { get; set; }

        public int showID { get; set; }
        public int userID { get; set; }
        public int count { get; set; }

        public string seats { get; set; }

    }
}
