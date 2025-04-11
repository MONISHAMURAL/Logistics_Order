using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Supplier
    {
        public int Id { get; set; }

        [Key]
        public int Supplier_Id { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Company_Name { get; set; }
        public string Supplier_Company_Address { get; set; }
        public string Supplier_Company_City { get; set; }
        public string Supplier_Company_State { get; set; }
        public string Supplier_Company_ZipCode { get; set; }
        public string Supplier_Company_Country { get; set; }
        public string Supplier_Phone { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Description { get; set; }
        public string Supplier_Company_Website { get; set; }

        public ICollection<Store> Stores { get; set; }
        [ForeignKey("Warehouse")]
        public int Warehouse_Id { get; set; }
        public Warehouse Warehouse { get; set; }

        public ICollection<Commodity> Commodity { get; set; }
        public ICollection<Order_Supplier> Order_Suppliers { get; set; }
        public ICollection<Shipping> Shippings { get; set; }

       


    }
}
