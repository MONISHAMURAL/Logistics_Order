using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Request
{
    public class ShippingType_Request
    {
        public int id { get; set; }
        [Key]
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
        public string Shipping_Type { get; set; } = string.Empty;
    }
}
