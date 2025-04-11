using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IOrder
    {
        public Task<IEnumerable<Order_Response>> GetAllOrders();
        public Task<Order_Response> GetOrderById(int id);
        public Task<string> CreateOrder(Order_Request order);
        public Task<string> UpdateOrder(int id, Order_Request order);
        public Task<string> DeleteOrder(int id);

    }
}
