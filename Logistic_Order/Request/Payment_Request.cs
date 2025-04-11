using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Payment_Request
    {
        public int Id { get; set; }
        [Key]
        public int Payment_Id { get; set; }
        public string Payment_Type { get; set; } = string.Empty;
        public string Payment_Description { get; set; } = string.Empty;
        public string Payment_Status { get; set; } = string.Empty;
        public DateTime Payment_Date { get; set; }
        [ForeignKey("TotalCost")]
        public int Cost_Id { get; set; }
      
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
     

    }
}
