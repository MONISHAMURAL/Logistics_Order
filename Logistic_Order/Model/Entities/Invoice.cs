using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Invoice
    {
        public int Id { get; set; }
        [Key]
        public int Invoice_No { get; set; }
        public string Invoice_Date { get; set; } = string.Empty;
        public string Invoice_Status { get; set; } = string.Empty;
        public decimal Invoice_Amount { get; set; }
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Payment")]
        public int Payment_Id { get; set; }
        public Payment Payment { get; set; }
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
        public Shipping Shipping { get; set; }

    }
}
