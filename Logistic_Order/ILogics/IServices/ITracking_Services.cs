using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ITracking_Services
    {
        Task<IEnumerable<Tracking_Response>> GetAllTrackingsAsync();
        Task<Tracking_Response> GetTrackingByIdAsync(int id);
        Task<string> CreateTrackingAsync(Tracking_Request tracking);
        Task<Tracking_Response> UpdateTracking(int id, Tracking_Request tracking);
        Task<bool> DeleteTracking(int id);
    }
}
