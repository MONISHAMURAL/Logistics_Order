using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IFeedbackServices
    {
        Task<string> AddFeedback(FeedbackRequest feedbackRequest);
        Task<Feedback_Response> UpdateFeedback(int Feedback_Id, FeedbackRequest feedbackRequest);
        Task<string> DeleteFeedback(int Feedback_Id);
        Task<Feedback_Response> GetFeedbackById(int Feedback_Id);
        Task<List<Feedback_Response>> GetAllFeedback();
    }
}
