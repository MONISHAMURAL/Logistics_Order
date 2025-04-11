using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class PermissionRole
    {
        public int Id { get; set; }
        [ForeignKey("Permissions")]
        [Key]
        public int Permission_Id { get; set; }
        public Permissions Permissions { get; set; }
        [ForeignKey("Roles")]
        public int Role_Id { get; set; }
        public Role Roles { get; set; }
    }
}
