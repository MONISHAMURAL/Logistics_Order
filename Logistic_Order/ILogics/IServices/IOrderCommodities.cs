using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IOrderCommodities
    {
        Task<string> CreateOrderCommoditiesAsync(OrderCommodities_Request orderCommodities);
        Task<OrderCommodities_Response> UpdateOrderCommoditiesAsync(OrderCommodities_Request orderCommodities);
        Task<bool> DeleteOrderCommoditiesAsync(int orderId);
        Task<string> GetOrderCommoditiesIdAsync(int orderId);
        Task<List<OrderCommodities_Response>> GetAllOrderCommoditiesAsync();
    }
}
