namespace Logistic_Order.Request
{
    public class Shipping_Route_Request
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Route_Description { get; set; }
        public string Route_Status { get; set; }
        public string Route_Tracking_History { get; set; }

        public double Distance { get; set; }
    }
}
