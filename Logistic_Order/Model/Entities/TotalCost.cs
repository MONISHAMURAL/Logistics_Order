using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class TotalCost
    {
        public int Id { get; set; }

        [Key]
        public int Cost_Id { get; set; }
        public int Discount { get; set; }

        public decimal Total_Amount { get; set; }

        [ForeignKey("shipping")]
        public int Shipping_Id { get; set; }
        public Shipping shipping { get; set; }
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        public Order Order { get; set; }
       
        public ICollection<Payment> Payment { get; set; }


    }
}
