using System.ComponentModel.DataAnnotations.Schema;

namespace Logistic_Order.Request
{
    public class FeedbackRequest
    {
        public int Id { get; set; }
        public int Feedback_Id { get; set; }

        public string Feedback_Message { get; set; }

        public string Feedback_Rating { get; set; }
        [ForeignKey("Buyers")]
        public int Buyer_Id { get; set; }
    }
}
