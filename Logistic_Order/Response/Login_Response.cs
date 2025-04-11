using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Login_Response
    {
        [Key]
        public int Login_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
