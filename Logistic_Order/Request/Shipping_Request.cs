using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class Shipping_Request
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
       

        [ForeignKey("WareHouse")]
        public int Warehouse_Id { get; set; }


        [ForeignKey("Supplier")]
        public int Supplier_Id { get; set; }

        [ForeignKey("ShippingType")]
        public int ShippingType_Id { get; set; }
    }
}
