using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Permissions
    {
        public int Id { get; set; }
        [Key]
        public int Permission_Id { get; set; }
        public string Permission_Type { get; set; }

        public ICollection<PermissionRole> PermissionRoles { get; set; }

    }
}
