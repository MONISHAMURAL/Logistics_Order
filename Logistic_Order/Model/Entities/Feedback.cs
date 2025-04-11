using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Model.Entities
{
    public class Feedback
    {
        public int Id { get; set; }
        [Key]
        public int Feedback_Id { get; set; }

        public string Feedback_Message { get; set; }

        public string Feedback_Rating { get; set; }
        [ForeignKey("Buyers")]
        public int Buyer_Id { get; set; }
        public Buyer Buyers { get; set; }




    }
}
