using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Login_Request
    {
        [Key]
        public int Login_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
