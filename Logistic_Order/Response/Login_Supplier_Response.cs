using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Login_Supplier_Response
    {
        [Required]
        [Key]
        public int Login_Supplier_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
    }
}
