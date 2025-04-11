using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Stock_Request
    {
        public int Id { get; set; }
        [Key]
        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
       
        [ForeignKey("Commodity")]
        public int Commodity_Id { get; set; }
    }
}
