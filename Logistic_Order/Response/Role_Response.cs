using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Role_Response
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }

    }
}
