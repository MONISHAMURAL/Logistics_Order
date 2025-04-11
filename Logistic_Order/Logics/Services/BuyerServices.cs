using Logistic_Order.Data;
using Logistic_Order.Logics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class BuyerServices:IBuyerServices
    {
        private readonly LoginDbContext _context;
        public BuyerServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddBuyers(Buyer_Request buyer_Request)
        {
            try
            {
                var existingBuyer = await _context.Buyers
                    .FirstOrDefaultAsync(b => b.Buyer_Id == buyer_Request.Buyer_Id);
                if (existingBuyer != null)
                {
                    return "Buyer already exists";
                }
                    Buyer buyer = new Buyer()
                {
                    Buyer_Company_Address = buyer_Request.Buyer_Company_Address,
                    Buyer_Company_City = buyer_Request.Buyer_Company_City,
                    Buyer_Company_Country = buyer_Request.Buyer_Company_Country,
                    Buyer_Company_Name = buyer_Request.Buyer_Company_Name,
                    Buyer_Id = buyer_Request.Buyer_Id,
                    Buyer_Company_State = buyer_Request.Buyer_Company_State,
                    Buyer_Company_ZipCode = buyer_Request.Buyer_Company_ZipCode,
                    Buyer_Description = buyer_Request.Buyer_Description,
                    Buyer_Email = buyer_Request.Buyer_Email,
                    Buyer_First_Name = buyer_Request.Buyer_First_Name,
                    Buyer_Last_Name = buyer_Request.Buyer_Last_Name,
                    Buyer_Phone = buyer_Request.Buyer_Phone

                };
                _context.Buyers.Add(buyer);
                await _context.SaveChangesAsync();
                return "Buyer added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Buyer_Response> UpdateBuyers(Buyer_Request buyer_Request)
        {
            try
            {
                var buyer = await _context.Buyers.FindAsync(buyer_Request.Buyer_Id);
                if (buyer == null)
                {
                    return null;
                }
                buyer.Buyer_Company_Address = buyer_Request.Buyer_Company_Address;
                buyer.Buyer_Company_City = buyer_Request.Buyer_Company_City;
                buyer.Buyer_Company_Country = buyer_Request.Buyer_Company_Country;
                buyer.Buyer_Company_Name = buyer_Request.Buyer_Company_Name;
                buyer.Buyer_Id = buyer_Request.Buyer_Id;
                buyer.Buyer_Company_State = buyer_Request.Buyer_Company_State;
                buyer.Buyer_Company_ZipCode = buyer_Request.Buyer_Company_ZipCode;
                buyer.Buyer_Description = buyer_Request.Buyer_Description;
                buyer.Buyer_Email = buyer_Request.Buyer_Email;
                buyer.Buyer_First_Name = buyer_Request.Buyer_First_Name;
                buyer.Buyer_Last_Name = buyer_Request.Buyer_Last_Name;
                buyer.Buyer_Phone = buyer_Request.Buyer_Phone;
                await _context.SaveChangesAsync();
                return new Buyer_Response()
                {
                    Buyer_Id = buyer.Buyer_Id,
                    Buyer_First_Name = buyer.Buyer_First_Name,
                    Buyer_Last_Name = buyer.Buyer_Last_Name,
                    Buyer_Company_Name = buyer.Buyer_Company_Name,
                    Buyer_Company_Address = buyer.Buyer_Company_Address,
                    Buyer_Company_City = buyer.Buyer_Company_City,
                    Buyer_Company_State = buyer.Buyer_Company_State,
                    Buyer_Company_ZipCode = buyer.Buyer_Company_ZipCode,
                    Buyer_Company_Country = buyer.Buyer_Company_Country,
                    Buyer_Phone = buyer.Buyer_Phone,
                    Buyer_Email = buyer.Buyer_Email,
                    Buyer_Description = buyer.Buyer_Description
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<bool> RemoveBuyers(int id)
        {
            try
            {
                var buyer = await _context.Buyers.FindAsync(id);
                if (buyer == null)
                {
                    return false;
                }
                _context.Buyers.Remove(buyer);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task<List<Buyer_Response>> GetAllBuyers()
        {
            try
            {
                var buyers = await _context.Buyers.ToListAsync();
                List<Buyer_Response> buyer_Responses = new List<Buyer_Response>();
                foreach (var buyer in buyers)
                {
                    buyer_Responses.Add(new Buyer_Response()
                    {
                        Buyer_Id = buyer.Buyer_Id,
                        Buyer_First_Name = buyer.Buyer_First_Name,
                        Buyer_Last_Name = buyer.Buyer_Last_Name,
                        Buyer_Company_Name = buyer.Buyer_Company_Name,
                        Buyer_Company_Address = buyer.Buyer_Company_Address,
                        Buyer_Company_City = buyer.Buyer_Company_City,
                        Buyer_Company_State = buyer.Buyer_Company_State,
                        Buyer_Company_ZipCode = buyer.Buyer_Company_ZipCode,
                        Buyer_Company_Country = buyer.Buyer_Company_Country,
                        Buyer_Phone = buyer.Buyer_Phone,
                        Buyer_Email = buyer.Buyer_Email,
                        Buyer_Description = buyer.Buyer_Description
                    });
                }
                return buyer_Responses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<Buyer_Response> GetBuyersById(int id)
        {
            try
            {
                var buyer = await _context.Buyers.FindAsync(id);
                if (buyer == null)
                {
                    return null;
                }
                return new Buyer_Response()
                {
                    Buyer_Id = buyer.Buyer_Id,
                    Buyer_First_Name = buyer.Buyer_First_Name,
                    Buyer_Last_Name = buyer.Buyer_Last_Name,
                    Buyer_Company_Name = buyer.Buyer_Company_Name,
                    Buyer_Company_Address = buyer.Buyer_Company_Address,
                    Buyer_Company_City = buyer.Buyer_Company_City,
                    Buyer_Company_State = buyer.Buyer_Company_State,
                    Buyer_Company_ZipCode = buyer.Buyer_Company_ZipCode,
                    Buyer_Company_Country = buyer.Buyer_Company_Country,
                    Buyer_Phone = buyer.Buyer_Phone,
                    Buyer_Email = buyer.Buyer_Email,
                    Buyer_Description = buyer.Buyer_Description
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

    }
}
