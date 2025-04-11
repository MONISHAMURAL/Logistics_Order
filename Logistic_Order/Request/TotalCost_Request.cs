using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class TotalCost_Request
    {
        public int Id { get; set; }
        [Key]
        public int Cost_Id { get; set; }
        public int Discount { get; set; }

        public decimal Total_Amount { get; set; }

        [ForeignKey("shipping")]
        public int Shipping_Id { get; set; }
       
        [ForeignKey("Order")]
        public int Order_No { get; set; }

       
    }
}
