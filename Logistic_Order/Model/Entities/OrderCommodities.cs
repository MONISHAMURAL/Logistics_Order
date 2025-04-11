using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class OrderCommodities
    {
        [Key]
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
        public Commodity Commodity { get; set; }
    }
}
