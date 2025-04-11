using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class PermissionRequest
    {
        public int Id { get; set; }
        [Key]
        public int Permission_Id { get; set; }
        public string Permission_Type { get; set; }
    }
}
