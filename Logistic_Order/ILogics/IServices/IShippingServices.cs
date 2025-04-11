using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IShippingServices
    {
        Task<List<Shipping_Response>> GetAllShipping();
        Task<Shipping_Response> GetShippingById(int id);
        Task<string> AddShipping(Shipping_Request shipping);
        Task<Shipping_Response> UpdateShipping(Shipping_Request shipping);
        Task<bool> DeleteShipping(int id);
       
    }
}
