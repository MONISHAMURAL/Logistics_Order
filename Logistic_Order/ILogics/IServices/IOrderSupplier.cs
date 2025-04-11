using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IOrderSupplier
    {
        Task<string> CreateOrderAsync(Order_Supplier_Request order);
        Task<Order_Supplier_Response> UpdateOrderAsync(Order_Supplier_Request order);
        Task<bool> DeleteOrderAsync(int orderId);
        Task<string> GetOrderIdAsync(int orderId);
        Task<List<Order_Supplier_Response>>GetAllOrdersAsync();


    }
}
