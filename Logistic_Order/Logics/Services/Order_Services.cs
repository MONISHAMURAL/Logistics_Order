using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Order_Services:IOrder
    {
        private readonly LoginDbContext _context;
        public Order_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order_Response>> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            return orders.Select(o => new Order_Response
            {
                Order_Cost = o.Order_Cost,
                Order_Date = o.Order_Date,
                Order_Status = o.Order_Status,
                Buyer_Id = o.Buyer_Id,
                Order_No = o.Order_No,
            });
        }
        public async Task<Order_Response> GetOrderById(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return null;
            }
            return new Order_Response
            {
                Order_No = order.Order_No,
                Order_Cost = order.Order_Cost,
                Order_Date = order.Order_Date,
                Order_Status = order.Order_Status,
                Buyer_Id = order.Buyer_Id,
            };
        }

        public async Task<string> CreateOrder(Order_Request order)
        {
            var newOrder = new Order
            {
                Order_No = order.Order_No,
                Order_Cost = order.Order_Cost,
                Order_Date = order.Order_Date,
                Order_Status = order.Order_Status,
                Buyer_Id = order.Buyer_Id,
            };
            _context.Orders.Add(newOrder);
            await _context.SaveChangesAsync();
            return "Order created successfully";
        }
        public async Task<string> UpdateOrder(int id, Order_Request order)
        {
            var existingOrder = await _context.Orders.FindAsync(id);
            if (existingOrder == null)
            {
                return "Order not found";
            }
           existingOrder.Order_No = order.Order_No;
            existingOrder.Order_Cost = order.Order_Cost;
            existingOrder.Order_Date = order.Order_Date;
            existingOrder.Order_Status = order.Order_Status;
            existingOrder.Buyer_Id = order.Buyer_Id;
            await _context.SaveChangesAsync();
            return "Order updated successfully";
        }
        public async Task<string> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return "Order not found";
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return "Order deleted successfully";
        }
    }
}
