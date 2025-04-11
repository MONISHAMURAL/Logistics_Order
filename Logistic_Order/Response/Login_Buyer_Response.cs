using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Login_Buyer_Response
    {
        [Key]
        public int Login_Buyer_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }

    }
}
