using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Store
    {
        public int Id { get; set; }
        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
