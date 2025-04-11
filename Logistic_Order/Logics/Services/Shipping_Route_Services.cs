using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Shipping_Route_Services:IShipping_Route
    {
       private readonly LoginDbContext loginDbContext;

        public Shipping_Route_Services(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<IEnumerable<Shipping_Route_Response>> GetAllShippingRoutesAsync()
        {
            var shippingRoutes = await loginDbContext.Shipping_Routes.ToListAsync();
            return shippingRoutes.Select(route => new Shipping_Route_Response
            {
                Id = route.Id,
                Origin = route.Origin,
                Destination = route.Destination,
                Route_Description = route.Route_Description,
                Route_Status = route.Route_Status,
                Route_Tracking_History = route.Route_Tracking_History,
                Distance = route.Distance
            });
        }
        public async Task<Shipping_Route_Response> GetShippingRouteByIdAsync(int id)
        {
            var shippingRoute = await loginDbContext.Shipping_Routes.FindAsync(id);
            if (shippingRoute == null)
            {
                return null;
            }
            return new Shipping_Route_Response
            {
                Id = shippingRoute.Id,
                Origin = shippingRoute.Origin,
                Destination = shippingRoute.Destination,
                Route_Description = shippingRoute.Route_Description,
                Route_Status = shippingRoute.Route_Status,
                Route_Tracking_History = shippingRoute.Route_Tracking_History,
                Distance = shippingRoute.Distance
            };
        }
        public async Task<string> CreateShippingRouteAsync(Shipping_Route_Request shippingRoute)
        {
            var newRoute = new Shipping_Route
            {
                Origin = shippingRoute.Origin,
                Destination = shippingRoute.Destination,
                Route_Description = shippingRoute.Route_Description,
                Route_Status = shippingRoute.Route_Status,
                Route_Tracking_History = shippingRoute.Route_Tracking_History,
                Distance = shippingRoute.Distance
            };
            await loginDbContext.Shipping_Routes.AddAsync(newRoute);
            await loginDbContext.SaveChangesAsync();
            return "Shipping route created successfully.";
        }
        public async Task<Shipping_Route_Response> UpdateShippingRoute(int id,Shipping_Route_Request shippingRoute)
        {
            var existingRoute = await loginDbContext.Shipping_Routes.FindAsync(shippingRoute.Id);
            if (existingRoute == null)
            {
                return null;
            }
            existingRoute.Origin = shippingRoute.Origin;
            existingRoute.Destination = shippingRoute.Destination;
            existingRoute.Route_Description = shippingRoute.Route_Description;
            existingRoute.Route_Status = shippingRoute.Route_Status;
            existingRoute.Route_Tracking_History = shippingRoute.Route_Tracking_History;
            existingRoute.Distance = shippingRoute.Distance;
            await loginDbContext.SaveChangesAsync();
            return new Shipping_Route_Response
            {
                Id = existingRoute.Id,
                Origin = existingRoute.Origin,
                Destination = existingRoute.Destination,
                Route_Description = existingRoute.Route_Description,
                Route_Status = existingRoute.Route_Status,
                Route_Tracking_History = existingRoute.Route_Tracking_History,
                Distance = existingRoute.Distance
            };
        }
        public async Task<bool> DeleteShippingRouteAsync(int id)
        {
            var shippingRoute = await loginDbContext.Shipping_Routes.FindAsync(id);
            if (shippingRoute == null)
            {
                return false;
            }
            loginDbContext.Shipping_Routes.Remove(shippingRoute);
            await loginDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteShippingRoute(int id)
        {
            var shippingRoute = await loginDbContext.Shipping_Routes.FindAsync(id);
            if (shippingRoute == null)
            {
                return false;
            }
            loginDbContext.Shipping_Routes.Remove(shippingRoute);
            await loginDbContext.SaveChangesAsync();
            return true;
        }
    }
}
