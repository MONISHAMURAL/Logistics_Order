using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Request
{
    public class Login_Buyer_Request
    {
        [Key]
        public int Login_Buyer_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }

    }
}
