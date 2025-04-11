namespace Logistic_Order.Model.Entities
{
    public class Shipping_Route
    {
        public int Id { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Route_Description { get; set; }
        public string Route_Status { get; set; }
        public string Route_Tracking_History { get; set; }

        public double Distance { get; set; }    

        public ICollection<Tracking> Trackings { get; set; } = new List<Tracking>();
    }
}
