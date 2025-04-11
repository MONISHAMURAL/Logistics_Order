using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class WareHouseServices : IWareHouse
    {
        private readonly LoginDbContext _context;
        public WareHouseServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddWareHouse(WareHouse_Request wareHouse_Request)
        {
            try
            {
                bool isExist = await _context.Warehouses.AnyAsync(w => w.Warehouse_Id == wareHouse_Request.Warehouse_Id);
                if (isExist)
                {
                    return "WareHouse already exists";
                }
                var wareHouse = new Warehouse();
                {
                    wareHouse.Warehouse_Address = wareHouse_Request.Warehouse_Address;
                    wareHouse.Warehouse_City = wareHouse_Request.Warehouse_City;
                    wareHouse.Warehouse_Country = wareHouse_Request.Warehouse_Country;
                    wareHouse.Warehouse_Description = wareHouse_Request.Warehouse_Description;
                    wareHouse.Warehouse_Email = wareHouse_Request.Warehouse_Email;
                    wareHouse.Warehouse_Id = wareHouse_Request.Warehouse_Id;
                    wareHouse.Warehouse_Name = wareHouse_Request.Warehouse_Name;
                    wareHouse.Warehouse_Phone = wareHouse_Request.Warehouse_Phone;
                    wareHouse.Warehouse_State = wareHouse_Request.Warehouse_State;
                    wareHouse.Warehouse_Website = wareHouse_Request.Warehouse_Website;
                    wareHouse.Warehouse_ZipCode = wareHouse_Request.Warehouse_ZipCode;

                };
                _context.Warehouses.Add(wareHouse);
                await _context.SaveChangesAsync();
                return "WareHouse added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> UpdateWareHouse(WareHouse_Request wareHouse_Request)
        {
            try
            {
                var wareHouse = await _context.Warehouses.FindAsync(wareHouse_Request.Id);
                if (wareHouse == null)
                {
                    return "WareHouse not found";
                }
                wareHouse.Warehouse_Address = wareHouse_Request.Warehouse_Address;
                wareHouse.Warehouse_City = wareHouse_Request.Warehouse_City;
                wareHouse.Warehouse_Country = wareHouse_Request.Warehouse_Country;
                wareHouse.Warehouse_Description = wareHouse_Request.Warehouse_Description;
                wareHouse.Warehouse_Email = wareHouse_Request.Warehouse_Email;
                wareHouse.Warehouse_Id = wareHouse_Request.Warehouse_Id;
                wareHouse.Warehouse_Name = wareHouse_Request.Warehouse_Name;
                wareHouse.Warehouse_Phone = wareHouse_Request.Warehouse_Phone;
                wareHouse.Warehouse_State = wareHouse_Request.Warehouse_State;
                wareHouse.Warehouse_Website = wareHouse_Request.Warehouse_Website;
                wareHouse.Warehouse_ZipCode = wareHouse_Request.Warehouse_ZipCode;
                _context.Entry(wareHouse).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return "WareHouse updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> DeleteWareHouse(int id)
        {
            try
            {
                var wareHouse = await _context.Warehouses.FindAsync(id);
                if (wareHouse == null)
                {
                    return "WareHouse not found";
                }
                _context.Warehouses.Remove(wareHouse);
                await _context.SaveChangesAsync();
                return "WareHouse deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<IEnumerable<WareHouse_Request>> GetWareHouse()
        {
            try
            {
                var wareHouse = await _context.Warehouses.ToListAsync();
                var wareHouse_Request = wareHouse.Select(w => new WareHouse_Request
                {
                    Id = w.Id,
                    Warehouse_Id = w.Warehouse_Id,
                    Warehouse_Name = w.Warehouse_Name,
                    Warehouse_Address = w.Warehouse_Address,
                    Warehouse_City = w.Warehouse_City,
                    Warehouse_State = w.Warehouse_State,
                    Warehouse_ZipCode = w.Warehouse_ZipCode,
                    Warehouse_Country = w.Warehouse_Country,
                    Warehouse_Phone = w.Warehouse_Phone,
                    Warehouse_Email = w.Warehouse_Email,
                    Warehouse_Description = w.Warehouse_Description,
                    Warehouse_Website = w.Warehouse_Website
                }).ToList();
                return wareHouse_Request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<WareHouse_Request> GetWareHouseById(int id)
        {
            try
            {
                var wareHouse = await _context.Warehouses.FindAsync(id);
                if (wareHouse == null)
                {
                    return null;
                }
                var wareHouse_Request = new WareHouse_Request
                {
                    Id = wareHouse.Id,
                    Warehouse_Id = wareHouse.Warehouse_Id,
                    Warehouse_Name = wareHouse.Warehouse_Name,
                    Warehouse_Address = wareHouse.Warehouse_Address,
                    Warehouse_City = wareHouse.Warehouse_City,
                    Warehouse_State = wareHouse.Warehouse_State,
                    Warehouse_ZipCode = wareHouse.Warehouse_ZipCode,
                    Warehouse_Country = wareHouse.Warehouse_Country,
                    Warehouse_Phone = wareHouse.Warehouse_Phone,
                    Warehouse_Email = wareHouse.Warehouse_Email,
                    Warehouse_Description = wareHouse.Warehouse_Description,
                    Warehouse_Website = wareHouse.Warehouse_Website
                };
                return wareHouse_Request;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

