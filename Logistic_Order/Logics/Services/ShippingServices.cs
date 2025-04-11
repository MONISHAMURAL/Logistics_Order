using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class ShippingServices:IShippingServices
    {
        private readonly LoginDbContext loginDbContext;
        public ShippingServices(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<List<Shipping_Response>> GetAllShipping()
        {
            try
            {
                var shippings = await loginDbContext.Shippings.ToListAsync();
                return shippings.Select(shipping => new Shipping_Response
                {
                    Shipping_Address = shipping.Shipping_Address,
                    Shipping_Carrier_Name = shipping.Shipping_Carrier_Name,
                    Shipping_City = shipping.Shipping_City,
                    Shipping_expected_Delivery = shipping.Shipping_expected_Delivery,
                    Shipping_Id = shipping.Shipping_Id,
                    Shipping_Status = shipping.Shipping_Status,
                    Supplier_Id = shipping.Supplier_Id,
                    Buyer_Id = shipping.Buyer_Id,
                    id = shipping.id,
                    Warehouse_Id = shipping.Warehouse_Id,
                     ShippingType_Id = shipping.ShippingType_Id,


                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving shipping data: " + ex.Message);
            }
        }
        public async Task<string> AddShipping(Shipping_Request request)
        {
            try
            {
                var shipping = new Shipping
                {
                    Shipping_Id = request.Shipping_Id,
                    id = request.id,
                    Shipping_Carrier_Name = request.Shipping_Carrier_Name,
                    Shipping_expected_Delivery = request.Shipping_expected_Delivery,
                    Shipping_Status = request.Shipping_Status,
                    Shipping_Address = request.Shipping_Address,
                    Shipping_City = request.Shipping_City,
                    Buyer_Id = request.Buyer_Id,
                    Warehouse_Id = request.Warehouse_Id,
                    Supplier_Id = request.Supplier_Id,
                    ShippingType_Id = request.ShippingType_Id,
                };    
                await loginDbContext.Shippings.AddAsync(shipping);
                await loginDbContext.SaveChangesAsync();
                return "Shipping added successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding shipping: " + ex.Message);
            }
        }
        public async Task<Shipping_Response> GetShippingById(int id)
        {
            try
            {
                var shipping = await loginDbContext.Shippings.FindAsync(id);
                if (shipping == null)
                {
                    return null;
                }
                return new Shipping_Response
                {
                    Shipping_Address = shipping.Shipping_Address,
                    Shipping_Carrier_Name = shipping.Shipping_Carrier_Name,
                    Shipping_City = shipping.Shipping_City,
                    Shipping_expected_Delivery = shipping.Shipping_expected_Delivery,
                    Shipping_Id = shipping.Shipping_Id,
                    Shipping_Status = shipping.Shipping_Status,
                    Supplier_Id = shipping.Supplier_Id,
                    Buyer_Id = shipping.Buyer_Id,
                    id = shipping.id,
                    Warehouse_Id = shipping.Warehouse_Id,
                    ShippingType_Id = shipping.ShippingType_Id,

                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving shipping data: " + ex.Message);
            }
        }
        public async Task<Shipping_Response> UpdateShipping(Shipping_Request request)
        {
            try
            {
                var shipping = await loginDbContext.Shippings.FindAsync(request.Shipping_Id);
                if (shipping == null)
                {
                    return null;
                }
                shipping.Shipping_Carrier_Name = request.Shipping_Carrier_Name;
                shipping.Shipping_expected_Delivery = request.Shipping_expected_Delivery;
                shipping.Shipping_Status = request.Shipping_Status;
                shipping.Shipping_Address = request.Shipping_Address;
                shipping.Shipping_City = request.Shipping_City;
                shipping.Buyer_Id = request.Buyer_Id;
                shipping.Warehouse_Id = request.Warehouse_Id;
                shipping.id = request.id;
                shipping.Shipping_Id = request.Shipping_Id;
                shipping.Supplier_Id = request.Supplier_Id;
                await loginDbContext.SaveChangesAsync();
                return new Shipping_Response
                {
                    Shipping_Address = shipping.Shipping_Address,
                    Shipping_Carrier_Name = shipping.Shipping_Carrier_Name,
                    Shipping_City = shipping.Shipping_City,
                    Shipping_expected_Delivery = shipping.Shipping_expected_Delivery,
                    Shipping_Id = shipping.Shipping_Id,
                    Shipping_Status = shipping.Shipping_Status,
                    Supplier_Id = shipping.Supplier_Id,
                    Buyer_Id = shipping.Buyer_Id,
                    id = shipping.id,
                    ShippingType_Id = shipping.ShippingType_Id,
                    Warehouse_Id = shipping.Warehouse_Id,
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating shipping: " + ex.Message);
            }
        }
        public async Task<bool> DeleteShipping(int id)
        {
            try
            {
                var shipping = await loginDbContext.Shippings.FindAsync(id);
                if (shipping == null)
                {
                    return false;
                }
                loginDbContext.Shippings.Remove(shipping);
                await loginDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            { 
                throw new Exception("Error deleting shipping: " + ex.Message);
                
            }
        }

        }
}
