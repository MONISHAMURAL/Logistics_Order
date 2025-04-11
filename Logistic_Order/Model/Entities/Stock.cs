using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Stock
    {
    public int Id { get; set; }
        [Key]
        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
        public Warehouse Warehouse { get; set; }
        [ForeignKey("Commodity")]
        public int Commodity_Id { get; set; }
        public Commodity Commodity { get; set; }
    }
}
