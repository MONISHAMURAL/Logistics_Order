using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Model.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }
        [Key]
        public int Warehouse_Id { get; set; }
        public string Warehouse_Name { get; set; }
        public string Warehouse_Address { get; set; }
        public string Warehouse_City { get; set; }
        public string Warehouse_State { get; set; }
        public string Warehouse_ZipCode { get; set; }
        public string Warehouse_Country { get; set; }
        public string Warehouse_Phone { get; set; }
        public string Warehouse_Email { get; set; }
        public string Warehouse_Description { get; set; }
        public string Warehouse_Website { get; set; }
        // Navigation property
        public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
        public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();

        public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        


    }
}
