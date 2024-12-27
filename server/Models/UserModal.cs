using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class UserModal
    {
        [Key]
        public int userID { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int balance { get; set; }
    }
}
