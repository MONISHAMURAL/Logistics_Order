using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Login
    {
        [Key]
        public int Login_Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<Login_Buyer> LoginBuyers { get; set; }
        public ICollection<Login_Supplier> LoginSuppliers { get; set; }
        public ICollection<Login_Role> LoginRoles { get; set; }


    }
}
