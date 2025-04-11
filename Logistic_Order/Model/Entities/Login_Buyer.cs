using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Login_Buyer
    {
        [Key]
        public int Login_Buyer_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        public Login Login { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
        public Buyer Buyer { get; set; }

    }
}
