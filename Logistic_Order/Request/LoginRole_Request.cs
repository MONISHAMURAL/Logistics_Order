using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class LoginRole_Request
    {
        [Required]
        [Key]
        public int Login_Role_Id { get; set; }
        [ForeignKey("Login")]
        public int Login_Id { get; set; }
        
        [ForeignKey("Role")]
        public int Role_Id { get; set; }
    }
}
