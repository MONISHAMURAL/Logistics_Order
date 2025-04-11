using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Response
{
    public class Order_Supplier_Response
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
    }
}
