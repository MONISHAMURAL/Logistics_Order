using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Commodity_Category_Request
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [Key]
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
    }
}
