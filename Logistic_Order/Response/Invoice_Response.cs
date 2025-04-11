using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Response
{
    public class Invoice_Response
    {
        public int Id { get; set; }
        public int Invoice_No { get; set; }
        public string Invoice_Date { get; set; } = string.Empty;
        public string Invoice_Status { get; set; } = string.Empty;
        public decimal Invoice_Amount { get; set; }
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        [ForeignKey("Payment")]
        public int Payment_Id { get; set; }
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
    }
}
