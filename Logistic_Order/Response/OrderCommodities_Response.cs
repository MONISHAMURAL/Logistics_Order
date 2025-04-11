using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class OrderCommodities_Response
    {

        [Key]
        [ForeignKey("Order")]
        public int Order_No { get; set; }
        
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
    }
}
