using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Order_Response
    {
        [Key]
        public int Order_No { get; set; }
        public string Order_Date { get; set; }
        public string Order_Status { get; set; } = string.Empty;

        public int Order_Cost { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
    }
}
