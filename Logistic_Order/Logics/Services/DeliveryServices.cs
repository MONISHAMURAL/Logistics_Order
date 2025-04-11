using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class DeliveryServices : IDeliveryServices
    {
        private readonly LoginDbContext _context;
        public DeliveryServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddDelivery(DeliveryRequest deliveryRequest)
        {
            var existingDelivery = await _context.Delivered.AnyAsync(d => d.Delivery_Carrier_Name == deliveryRequest.Delivery_Carrier_Name && d.Shipping_Id == deliveryRequest.Shipping_Id);
            if (existingDelivery)
            {
                return "Delivery already exists";
            }
            var delivery = new Delivery
            {
                Delivery_Carrier_Name = deliveryRequest.Delivery_Carrier_Name,
                Delivery_Date = deliveryRequest.Delivery_Date.ToUniversalTime(),
                Delivery_Status = deliveryRequest.Delivery_Status,
                Delivery_Confirmation = deliveryRequest.Delivery_Confirmation,
                Delivery_Tracking_History = deliveryRequest.Delivery_Tracking_History,
                Shipping_Id = deliveryRequest.Shipping_Id,
                Delivery_Id=deliveryRequest.Delivery_Id,
                Id = deliveryRequest.Id
            };
            await _context.Delivered.AddAsync(delivery);
            await _context.SaveChangesAsync();
            return "Delivery added successfully";
        }
        public async Task<string> UpdateDelivery(int id, DeliveryRequest deliveryRequest)
        {
            var delivery = await _context.Delivered.FindAsync(id);
            if (delivery == null)
            {
                return "Delivery not found";
            }
            delivery.Delivery_Carrier_Name = deliveryRequest.Delivery_Carrier_Name;
            delivery.Delivery_Status = deliveryRequest.Delivery_Status;
            delivery.Delivery_Confirmation = deliveryRequest.Delivery_Confirmation;
            delivery.Delivery_Tracking_History = deliveryRequest.Delivery_Tracking_History;
            delivery.Shipping_Id = deliveryRequest.Shipping_Id;
            delivery.Delivery_Date = DateTime.Now;
            delivery.Delivery_Id = deliveryRequest.Delivery_Id;
            delivery.Id = deliveryRequest.Id;


            _context.Delivered.Update(delivery);

            await _context.SaveChangesAsync();
            return "Delivery updated successfully";
        }
        public async Task<string> DeleteDelivery(int id)
        {
            var delivery = await _context.Delivered.FindAsync(id);
            if (delivery == null)
            {
                return "Delivery not found";
            }
            _context.Delivered.Remove(delivery);
            await _context.SaveChangesAsync();
            return "Delivery deleted successfully";
        }
        public async Task<Delivery_Response> GetDeliveryById(int id)
        {
            var delivery = await _context.Delivered.FindAsync(id);
            if (delivery == null)
            {
                return null;
            }
            delivery.Delivery_Date = DateTime.Now;
            delivery.Delivery_Status = delivery.Delivery_Status;
            delivery.Delivery_Confirmation = delivery.Delivery_Confirmation;
            delivery.Delivery_Tracking_History = delivery.Delivery_Tracking_History;
            delivery.Shipping_Id = delivery.Shipping_Id;
            delivery.Delivery_Carrier_Name = delivery.Delivery_Carrier_Name;
            delivery.Delivery_Id = delivery.Delivery_Id;
            delivery.Id = delivery.Id;
            

            var deliveryResponse = new Delivery_Response
            {
                Delivery_Id = delivery.Delivery_Id,
                Delivery_Carrier_Name = delivery.Delivery_Carrier_Name,
                Delivery_Date = delivery.Delivery_Date,
                Delivery_Status = delivery.Delivery_Status,
                Delivery_Confirmation = delivery.Delivery_Confirmation,
                Delivery_Tracking_History = delivery.Delivery_Tracking_History,
                Shipping_Id = delivery.Shipping_Id,
                Id = delivery.Id,
            };
            return deliveryResponse;

        }
        public async Task<List<Delivery_Response>> GetAllDelivery()
        {
            var deliveries = await _context.Delivered.ToListAsync();
            if (deliveries == null || deliveries.Count == 0)
            {
                return null;
            }
            return deliveries.Select(d => new Delivery_Response
            {
                Delivery_Id = d.Delivery_Id,
                Delivery_Carrier_Name = d.Delivery_Carrier_Name,
                Delivery_Date = d.Delivery_Date,
                Delivery_Status = d.Delivery_Status,
                Delivery_Confirmation = d.Delivery_Confirmation,
                Delivery_Tracking_History = d.Delivery_Tracking_History,
                Shipping_Id = d.Shipping_Id,
                Id = d.Id
            }).ToList();
        }

    }
}
