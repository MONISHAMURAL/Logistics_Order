using System.ComponentModel.DataAnnotations;

namespace Logistic_Order.Model.Entities
{
    public class Buyer
    {
        [Key]
        public int Buyer_Id { get; set; }
        public string Buyer_First_Name { get; set; }
        public string Buyer_Last_Name { get; set; }
        public string Buyer_Company_Name { get; set; }
        public string Buyer_Company_Address { get; set; }
        public string Buyer_Company_City { get; set; }
        public string Buyer_Company_State { get; set; }
        public string Buyer_Company_ZipCode { get; set; }
        public string Buyer_Company_Country { get; set; }
        public string Buyer_Phone { get; set; }
        public string Buyer_Email { get; set; }
        public string Buyer_Description { get; set; }

        public Feedback Feedback { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Shipping> Shippings { get; set; }


    }
}
