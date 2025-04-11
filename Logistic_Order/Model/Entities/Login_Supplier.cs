using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Login_Supplier
    {
        [Required]
        [Key]
        public int Login_Supplier_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        public Login Login { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        public Supplier Supplier { get; set; }
    }
}
