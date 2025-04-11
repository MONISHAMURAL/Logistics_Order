using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IShipping_Route
    {
        Task<IEnumerable<Shipping_Route_Response>> GetAllShippingRoutesAsync();
        Task<Shipping_Route_Response> GetShippingRouteByIdAsync(int id);
        Task<string> CreateShippingRouteAsync(Shipping_Route_Request shippingRoute);
        Task<Shipping_Route_Response> UpdateShippingRoute(int id,Shipping_Route_Request shippingRoute);
        Task<bool> DeleteShippingRoute(int id);
    }
}
