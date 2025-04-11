using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class ShippingType_Services : IShippingType
    {
        private readonly LoginDbContext loginDbContext;
        public ShippingType_Services(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<IEnumerable<Shipping_Type_Response>> GetShippingTypeAsync()
        {
            var shippingTypes = await loginDbContext.ShippingTypes.ToListAsync();
            return shippingTypes.Select(st => new Shipping_Type_Response
            {
                id = st.Id,
                Shipping_Id = st.Shipping_Id,
                Shipping_Type = st.Shipping_Type
            });
        }
        public async Task<Shipping_Type_Response> GetShippingTypeByIdAsync(int id)
        {
            var shippingType = await loginDbContext.ShippingTypes.FindAsync(id);
            if (shippingType == null)
            {
                throw new Exception("Shipping type not found");
            }
            return new Shipping_Type_Response
            {
                id = shippingType.Id,
                Shipping_Id = shippingType.Shipping_Id,
                Shipping_Type = shippingType.Shipping_Type
            };
        }
        public async Task<Shipping_Type_Response> CreateShippingTypeAsync(ShippingType_Request shippingType)
        {
            var newShippingType = new ShippingType
            {
                Shipping_Id = shippingType.Shipping_Id,
                Shipping_Type = shippingType.Shipping_Type,
                Id = shippingType.id,

            };
            await loginDbContext.ShippingTypes.AddAsync(newShippingType);
            await loginDbContext.SaveChangesAsync();
            return new Shipping_Type_Response
            {
                id = newShippingType.Id,
                Shipping_Id = newShippingType.Shipping_Id,
                Shipping_Type = newShippingType.Shipping_Type
            };
        }
        public async Task<Shipping_Type_Response> UpdateShippingTypeAsync(int id, Shipping_Type_Response shippingType)
        {
            var existingShippingType = await loginDbContext.ShippingTypes.FindAsync(id);
            if (existingShippingType == null)
            {
                throw new Exception("Shipping type not found");
            }
            existingShippingType.Shipping_Id = shippingType.Shipping_Id;
            existingShippingType.Shipping_Type = shippingType.Shipping_Type;
            await loginDbContext.SaveChangesAsync();
            return new Shipping_Type_Response
            {
                id = existingShippingType.Id,
                Shipping_Id = existingShippingType.Shipping_Id,
                Shipping_Type = existingShippingType.Shipping_Type
            };
        }
        public async Task<bool> DeleteShippingTypeAsync(int id)
        {
            var shippingType = await loginDbContext.ShippingTypes.FindAsync(id);
            if (shippingType == null)
            {
                throw new Exception("Shipping type not found");
            }
            loginDbContext.ShippingTypes.Remove(shippingType);
            await loginDbContext.SaveChangesAsync();
            return true;

        }
    }
}
