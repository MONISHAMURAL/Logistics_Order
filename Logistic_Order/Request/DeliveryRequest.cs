using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Logistic_Order.Model.Entities;

namespace Logistic_Order.Request
{
    public class DeliveryRequest
    {
        public int Id { get; set; }
        [Key]
        public int Delivery_Id { get; set; }
        public string Delivery_Carrier_Name { get; set; } = string.Empty;

        public DateTime Delivery_Date { get; set; } =  DateTime.UtcNow;
        public string Delivery_Status { get; set; } = string.Empty;

        public string Delivery_Confirmation { get; set; } = string.Empty;
        public string Delivery_Tracking_History { get; set; } = string.Empty;
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
        
    }
}
