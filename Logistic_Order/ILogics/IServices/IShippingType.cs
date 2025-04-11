using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IShippingType
    {
        Task <IEnumerable<Shipping_Type_Response>> GetShippingTypeAsync ();
        Task<Shipping_Type_Response> GetShippingTypeByIdAsync(int id);
        Task<Shipping_Type_Response> CreateShippingTypeAsync(ShippingType_Request shippingType);
        Task<Shipping_Type_Response> UpdateShippingTypeAsync(int id, Shipping_Type_Response shippingType);
        Task<bool> DeleteShippingTypeAsync(int id);
    }
}
