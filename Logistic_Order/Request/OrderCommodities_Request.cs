using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class OrderCommodities_Request
    {

        [Key]
        [ForeignKey("Order")]
        public int Order_No { get; set; }
       
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
    }
}
