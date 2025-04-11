using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        [Key]
        public int Payment_Id { get; set; }
        public string Payment_Type { get; set; } = string.Empty;
        public string Payment_Description { get; set; } = string.Empty;
        public string Payment_Status { get; set; } = string.Empty;
        public DateTime Payment_Date { get; set; }
       
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
        public Buyer Buyer { get; set; }

        public Invoice Invoice { get; set; }
        [ForeignKey("Total Cost")]
        public int Cost_Id { get; set; }

        public TotalCost TotalCosts { get; set; }

    }
}
