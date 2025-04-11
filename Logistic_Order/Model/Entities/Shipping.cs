using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Shipping
    {
        public int id { get; set; }
        [Key]
        public int Shipping_Id { get; set; }
        public string Shipping_Carrier_Name { get; set; } = string.Empty;
        public DateTime Shipping_expected_Delivery { get; set; }
        public string Shipping_Status { get; set; } = string.Empty;
        public string Shipping_Address { get; set; } = string.Empty;
        public string Shipping_City { get; set; } = string.Empty;

        [ForeignKey("Buyer")]
        public int Buyer_Id { get; set; }
        public Buyer Buyer { get; set; }

        [ForeignKey("WareHouse")]
        public int Warehouse_Id { get; set; }
        public Warehouse WareHouses { get; set; }

        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }
        public Supplier Supplier { get; set; }

        [ForeignKey("ShippingType")]
        public int ShippingType_Id { get; set; }
        public ShippingType ShippingTypes { get; set; }

        public ICollection<Tracking> Trackings { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public TotalCost TotalCosts { get; set; }

        public Delivery Delivery { get; set; }
       
    }
}
