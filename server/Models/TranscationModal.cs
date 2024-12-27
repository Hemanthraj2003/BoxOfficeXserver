using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class TranscationModal
    {
        [Key]
        public int transcationID { get; set; }
        public int userID { get; set; }

        public int ticketID { get; set; }
        public int transactionAMT { get; set; }
        public string transactionType { get; set; }
    }
}
