using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Commodity_Category
    {
        public int Id { get; set; }
        [Key]
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }
        public Commodity Commodity { get; set; }
        public string CategoryName { get; set; }
    }
}
