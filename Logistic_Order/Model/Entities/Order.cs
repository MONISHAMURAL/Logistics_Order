using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Order
    {
        [Key]
        public int Order_No { get; set; }
        public string Order_Date { get; set; }
        public string Order_Status { get; set; } = string.Empty;

        public int Order_Cost { get; set; }
        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
        public Buyer Buyer { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order_Supplier> OrderSuppliers { get; set; }
        public ICollection<OrderCommodities> OrderCommodities { get; set; } 

        public TotalCost TotalCosts { get; set; }

    }
}
