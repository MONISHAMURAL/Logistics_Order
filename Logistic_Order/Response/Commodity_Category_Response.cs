using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Commodity_Category_Response
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        [Key]
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
        public Commodity_Response Commodity { get; set; } = new Commodity_Response();
    }
}

