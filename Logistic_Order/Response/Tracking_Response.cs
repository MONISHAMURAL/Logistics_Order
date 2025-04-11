using Logistic_Order.Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Response
{
    public class Tracking_Response
    {
        public int Id { get; set; }
        [Key]
        public int Tracking_Id { get; set; }
        public DateTime TrackingDate { get; set; }
        public string Tracking_Status { get; set; }
        public string Tracking_History { get; set; }
        public string Current_location { get; set; }

        [ForeignKey("Route")]
        public int Route_Id { get; set; }
        
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
    }
}
