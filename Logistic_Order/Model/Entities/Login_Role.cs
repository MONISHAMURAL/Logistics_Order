using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Login_Role
    {
        [Required]
        [Key]
        public int Login_Role_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        public Login Login { get; set; }
        [ForeignKey("Role")]
        public int Role_Id { get; set; }
        public Role Role { get; set; }

    }
}
