using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Tracking
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
        public Shipping_Route Shipping_Routes { get; set; }
        [ForeignKey("Shipping")]
        public int Shipping_Id { get; set; }
        public Shipping Shipping { get; set; }


    }
}
