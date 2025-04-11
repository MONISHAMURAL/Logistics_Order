using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Model.Entities
{
    public class Role
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }

        public ICollection<PermissionRole> PermissionRoles { get; set; }
    }
}
