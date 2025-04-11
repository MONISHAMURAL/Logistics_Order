using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IDeliveryServices
    {
  Task<string>AddDelivery(DeliveryRequest deliveryRequest);
        Task<string> UpdateDelivery(int id, DeliveryRequest deliveryRequest);
        Task<string> DeleteDelivery(int id);
        Task<Delivery_Response> GetDeliveryById(int id);
        Task<List<Delivery_Response>> GetAllDelivery();


    }
}
