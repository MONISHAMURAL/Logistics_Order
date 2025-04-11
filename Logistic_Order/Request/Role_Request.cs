using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Role_Request
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }

    }
}
