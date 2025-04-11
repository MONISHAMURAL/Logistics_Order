using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Order_supplier_Services : IOrderSupplier
    {
        private readonly LoginDbContext _context;
        public Order_supplier_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateOrderAsync(Order_Supplier_Request order)
        {
            var newOrder = new Order_Supplier
            {
                Order_No = order.Order_No,
                Supplier_Id = order.Supplier_Id,
            };
            await _context.Order_Suppliers.AddAsync(newOrder);
            await _context.SaveChangesAsync();
            return "Order created successfully";
        }
        public async Task<Order_Supplier_Response> UpdateOrderAsync(Order_Supplier_Request order)
        {
            var existingOrder = await _context.Order_Suppliers.FindAsync(order.Order_No);
            if (existingOrder == null)
            {
                return null;
            }
            existingOrder.Order_No = order.Order_No;
            existingOrder.Supplier_Id = order.Supplier_Id;
            await _context.SaveChangesAsync();
            return new Order_Supplier_Response
            {

                Order_No = existingOrder.Order_No,
                Supplier_Id = existingOrder.Supplier_Id,
            };
        }
        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _context.Order_Suppliers.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            _context.Order_Suppliers.Remove(order);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string> GetOrderIdAsync(int orderId)
        {
            var order = await _context.Order_Suppliers.FindAsync(orderId);
            if (order == null)
            {
                return "Order not found";
            }
            return $"Order No: {order.Order_No}, Supplier Id: {order.Supplier_Id}";
        }
        public async Task<List<Order_Supplier_Response>> GetAllOrdersAsync()
        {
            var orders = await _context.Order_Suppliers.ToListAsync();
            var result = new List<Order_Supplier_Response>();

            foreach (var order in orders)
            {
                result.Add(new Order_Supplier_Response
                {
                    Order_No = order.Order_No,
                    Supplier_Id = order.Supplier_Id,
                });
            }

            return result;
        }

        public async Task<Order_Supplier_Response> GetOrderByIdAsync(int orderId)
        {
            var order = await _context.Order_Suppliers.FindAsync(orderId);
            if (order == null)
            {
                return null;
            }
            return new Order_Supplier_Response
            {
                Order_No = order.Order_No,
                Supplier_Id = order.Supplier_Id,
            };
        }
    }
}
