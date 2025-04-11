using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class OrderCommodities_Services:IOrderCommodities
    {
     private readonly LoginDbContext loginDbContext;
        
     public OrderCommodities_Services(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }

        public async Task<string> CreateOrderCommoditiesAsync(OrderCommodities_Request orderCommodities)
        {
            var newOrderCommodities = new OrderCommodities
            {
  
                Order_No = orderCommodities.Order_No,
                CommodityId = orderCommodities.CommodityId,
            };
            await loginDbContext.OrderCommodities.AddAsync(newOrderCommodities);
            await loginDbContext.SaveChangesAsync();
            return "Order commodities created successfully";
        }
        public async Task<OrderCommodities_Response> UpdateOrderCommoditiesAsync(OrderCommodities_Request orderCommodities)
        {
            var existingOrderCommodities = await loginDbContext.OrderCommodities.FindAsync(orderCommodities.Order_No);
            if (existingOrderCommodities == null)
            {
                return null;
            }
            existingOrderCommodities.Order_No = orderCommodities.Order_No;
            existingOrderCommodities.CommodityId = orderCommodities.CommodityId;
            await loginDbContext.SaveChangesAsync();
            return new OrderCommodities_Response
            {
                Order_No = existingOrderCommodities.Order_No,
                CommodityId = existingOrderCommodities.CommodityId,
            };
        }
        public async Task<bool> DeleteOrderCommoditiesAsync(int orderId)
        {
            var orderCommodities = await loginDbContext.OrderCommodities.FindAsync(orderId);
            if (orderCommodities == null)
            {
                return false;
            }
            loginDbContext.OrderCommodities.Remove(orderCommodities);
            await loginDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<string> GetOrderCommoditiesIdAsync(int orderId)
        {
            var orderCommodities = await loginDbContext.OrderCommodities.FindAsync(orderId);
            if (orderCommodities == null)
            {
                return null;
            }
            return orderCommodities.Order_No.ToString();
        }
        public async Task<List<OrderCommodities_Response>> GetAllOrderCommoditiesAsync()
        {
            var orderCommoditiesList = await loginDbContext.OrderCommodities.ToListAsync();
            return orderCommoditiesList.Select(order => new OrderCommodities_Response
            {
                Order_No = order.Order_No,
                CommodityId = order.CommodityId,
            }).ToList();
        }

    }
}
