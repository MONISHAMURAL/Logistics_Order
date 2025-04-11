using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Tracking_Services : ITracking_Services
    {
        private readonly LoginDbContext _context;
        public Tracking_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Tracking_Response>> GetAllTrackingsAsync()
        {
            try
            {
                var trackings = await _context.Trackings.ToListAsync();
                return trackings.Select(t => new Tracking_Response
                {
                    Id = t.Id,
                    Current_location = t.Current_location,
                    Route_Id = t.Route_Id,
                    Shipping_Id = t.Shipping_Id,
                    TrackingDate = t.TrackingDate,
                    Tracking_History = t.Tracking_History,
                    Tracking_Id = t.Tracking_Id,
                    Tracking_Status = t.Tracking_Status,
                }).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception("Error retrieving trackings: " + ex.Message);
            }
        }
        public async Task<Tracking_Response> GetTrackingByIdAsync(int id)
        {
            try
            {
                var tracking = await _context.Trackings.FindAsync(id);
                if (tracking == null)
                {
                    throw new Exception("Tracking not found");
                }
                return new Tracking_Response
                {
                    Id = tracking.Id,
                    Current_location = tracking.Current_location,
                    Route_Id = tracking.Route_Id,
                    Shipping_Id = tracking.Shipping_Id,
                    TrackingDate = tracking.TrackingDate,
                    Tracking_History = tracking.Tracking_History,
                    Tracking_Id = tracking.Tracking_Id,
                    Tracking_Status = tracking.Tracking_Status,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving tracking: " + ex.Message);
            }

        }
        public async Task<string> CreateTrackingAsync(Tracking_Request tracking)
        {
            try
            {
                var newTracking = new Model.Entities.Tracking
                {
                    Current_location = tracking.Current_location,
                    Route_Id = tracking.Route_Id,
                    Shipping_Id = tracking.Shipping_Id,
                    TrackingDate = tracking.TrackingDate,
                    Tracking_History = tracking.Tracking_History,
                    Tracking_Status = tracking.Tracking_Status,
                    Tracking_Id = tracking.Tracking_Id,
                    Id = tracking.Id,
                };
                await _context.Trackings.AddAsync(newTracking);
                await _context.SaveChangesAsync();
                return "Tracking created successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Error creating tracking: " + ex.Message);
            }
        }
        public async Task<Tracking_Response> UpdateTracking(int id, Tracking_Request tracking)
        {
            try
            {
                var existingTracking = await _context.Trackings.FindAsync(id);
                if (existingTracking == null)
                {
                    throw new Exception("Tracking not found");
                }
                existingTracking.Current_location = tracking.Current_location;
                existingTracking.Route_Id = tracking.Route_Id;
                existingTracking.Shipping_Id = tracking.Shipping_Id;
                existingTracking.TrackingDate = tracking.TrackingDate;
                existingTracking.Tracking_History = tracking.Tracking_History;
                existingTracking.Tracking_Status = tracking.Tracking_Status;
                existingTracking.Tracking_Id = tracking.Tracking_Id;
                existingTracking.Id = tracking.Id;
                _context.Trackings.Update(existingTracking);
                await _context.SaveChangesAsync();
                return new Tracking_Response
                {
                    Id = existingTracking.Id,
                    Current_location = existingTracking.Current_location,
                    Route_Id = existingTracking.Route_Id,
                    Shipping_Id = existingTracking.Shipping_Id,
                    TrackingDate = existingTracking.TrackingDate,
                    Tracking_History = existingTracking.Tracking_History,
                    Tracking_Id = existingTracking.Tracking_Id,
                    Tracking_Status = existingTracking.Tracking_Status,
                    
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating tracking: " + ex.Message);
            }
        }
        public async Task<bool> DeleteTracking(int id)
        {
            try
            {
                var tracking = await _context.Trackings.FindAsync(id);
                if (tracking == null)
                {
                    throw new Exception("Tracking not found");
                }
                _context.Trackings.Remove(tracking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting tracking: " + ex.Message);
            }
        }
    }
}
