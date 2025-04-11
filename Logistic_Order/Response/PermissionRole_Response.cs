using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Response
{
    public class PermissionRole_Response
    {
        public int Id { get; set; }
        [ForeignKey("Permissions")]
        public int Permission_Id { get; set; }
        [ForeignKey("Roles")]
        public int Role_Id { get; set; }
    }
}
