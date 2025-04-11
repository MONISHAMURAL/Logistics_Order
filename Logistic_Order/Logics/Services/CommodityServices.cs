using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class CommodityServices : ICommodityServices
    {
        private readonly LoginDbContext _context;
        public CommodityServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<List<Commodity_Response>> GetAllCommodities()
        {
            try
            {
              
                var commodities = await _context.Commodities.ToListAsync();
                return commodities.Select(c => new Commodity_Response
                {
                    Id = c.Id,
                    Commodity_Id = c.Commodity_Id,
                    Commodity_Name = c.Commodity_Name,
                    Commodity_Description = c.Commodity_Description,
                    Commodity_Type = c.Commodity_Type,
                    Commodity_Weight = c.Commodity_Weight,
                    Commodity_Quantity = c.Commodity_Quantity,
                    Commodity_Price = c.Commodity_Price,
                    Commodity_Unit = c.Commodity_Unit,
                    Commodity_Status = c.Commodity_Status,
                    Commodity_Date = c.Commodity_Date,
                    Commodity_Expiry = c.Commodity_Expiry,
                    Supplier_Id = c.Supplier_Id
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving commodities: " + ex.Message);
            }
        }
        public async Task<Commodity_Response> GetCommodityById(int id)
        {
            try
            {
                var commodity = await _context.Commodities.FindAsync(id);
                if (commodity == null)
                {
                    throw new Exception("Commodity not found");
                }
                return new Commodity_Response
                {
                    Id = commodity.Id,
                    Commodity_Id = commodity.Commodity_Id,
                    Commodity_Name = commodity.Commodity_Name,
                    Commodity_Description = commodity.Commodity_Description,
                    Commodity_Type = commodity.Commodity_Type,
                    Commodity_Weight = commodity.Commodity_Weight,
                    Commodity_Quantity = commodity.Commodity_Quantity,
                    Commodity_Price = commodity.Commodity_Price,
                    Commodity_Unit = commodity.Commodity_Unit,
                    Commodity_Status = commodity.Commodity_Status,
                    Commodity_Date = commodity.Commodity_Date,
                    Commodity_Expiry = commodity.Commodity_Expiry,
                    Supplier_Id = commodity.Supplier_Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving commodity: " + ex.Message);
            }
        }
        public async Task<string> AddCommodity(Commodity_Request commodity)
        {
            try
            {
                bool exists = await _context.Commodities.AnyAsync(x => x.Commodity_Id == commodity.Commodity_Id);

                if (exists)
                {
                    return "Commodity already exists";
                }
                var newCommodity = new Model.Entities.Commodity
                {
                    Id = commodity.Id,
                    Commodity_Id = commodity.Commodity_Id,
                    Commodity_Name = commodity.Commodity_Name,
                    Commodity_Description = commodity.Commodity_Description,
                    Commodity_Type = commodity.Commodity_Type,
                    Commodity_Weight = commodity.Commodity_Weight,
                    Commodity_Quantity = commodity.Commodity_Quantity,
                    Commodity_Price = commodity.Commodity_Price,
                    Commodity_Unit = commodity.Commodity_Unit,
                    Commodity_Status = commodity.Commodity_Status,
                    Commodity_Date = commodity.Commodity_Date,
                    Commodity_Expiry = commodity.Commodity_Expiry,
                    Supplier_Id = commodity.Supplier_Id
                };
                _context.Commodities.Add(newCommodity);
                await _context.SaveChangesAsync();
                return "Commodity added successfully";
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding commodity: " + ex.Message);
            }
        }
        public async Task<bool> DeleteCommodity(int id)
        {
            try
            {
                var commodity = await _context.Commodities.FindAsync(id);
                if (commodity == null)
                {
                    throw new Exception("Commodity not found");
                }
                _context.Commodities.Remove(commodity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting commodity: " + ex.Message);

            }
        }
        public async Task<Commodity_Response> UpdateCommodity(Commodity_Request commodity)
        {
            try
            {
                var res = await _context.Commodities.FindAsync(commodity.Id);
                if (res == null)
                {
                    throw new Exception("Commodity not found");
                }
                res.Commodity_Id = commodity.Commodity_Id;
                res.Commodity_Name = commodity.Commodity_Name;
                res.Commodity_Description = commodity.Commodity_Description;
                res.Commodity_Type = commodity.Commodity_Type;
                res.Commodity_Weight = commodity.Commodity_Weight;
                res.Commodity_Quantity = commodity.Commodity_Quantity;
                res.Commodity_Price = commodity.Commodity_Price;
                res.Commodity_Unit = commodity.Commodity_Unit;
                res.Commodity_Status = commodity.Commodity_Status;
                res.Commodity_Date = commodity.Commodity_Date;
                res.Commodity_Expiry = commodity.Commodity_Expiry;
                res.Supplier_Id = commodity.Supplier_Id;
                _context.Commodities.Update(res);
                await _context.SaveChangesAsync();
                return new Commodity_Response
                {
                    Id = res.Id,
                    Commodity_Id = res.Commodity_Id,
                    Commodity_Name = res.Commodity_Name,
                    Commodity_Description = res.Commodity_Description,
                    Commodity_Type = res.Commodity_Type,
                    Commodity_Weight = res.Commodity_Weight,
                    Commodity_Quantity = res.Commodity_Quantity,
                    Commodity_Price = res.Commodity_Price,
                    Commodity_Unit = res.Commodity_Unit,
                    Commodity_Status = res.Commodity_Status,
                    Commodity_Date = res.Commodity_Date,
                    Commodity_Expiry = res.Commodity_Expiry,
                    Supplier_Id = res.Supplier_Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating commodity: " + ex.Message);
            }

        }
        }
}