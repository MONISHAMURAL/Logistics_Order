using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Order_Supplier
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        [Key]
        public int Order_No { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        public Supplier Supplier { get; set; }
    }
}
