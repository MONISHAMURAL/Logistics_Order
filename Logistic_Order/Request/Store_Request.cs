using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Request
{
    public class Store_Request
    {
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        
        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
    }
}
