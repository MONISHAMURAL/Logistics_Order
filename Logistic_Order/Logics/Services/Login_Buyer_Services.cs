using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class Login_Buyer_Services : ILogin_Buyer
    {
        private readonly LoginDbContext _context;
        public Login_Buyer_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> CreateLogin_Buyer(Login_Buyer_Request login_Buyer)
        {
            if (login_Buyer == null)
            {
                return "Invalid input: login_Buyer is null";
            }

            var login = new Login_Buyer
            {
                Login_Buyer_Id = login_Buyer.Login_Buyer_Id,
                Login_Id = login_Buyer.Login_Id,
                Buyer_Id = login_Buyer.Buyer_Id
            };

            _context.LoginBuyers.Add(login);
            await _context.SaveChangesAsync();

            return "Login_Buyer created successfully";
        }
        public async Task<string> DeleteLogin_Buyer(int id)
        {
            var login_Buyer = await _context.LoginBuyers.FindAsync(id);
            if (login_Buyer == null)
            {
                return "Login_Buyer not found";
            }
            _context.LoginBuyers.Remove(login_Buyer);
            await _context.SaveChangesAsync();
            return "Login_Buyer deleted successfully";
        }
        public async Task<IEnumerable<Login_Buyer_Response>> GetAllLogin_Buyers()
        {
            var login_Buyers = await _context.LoginBuyers.ToListAsync();
            return login_Buyers.Select(l => new Login_Buyer_Response
            {
                Login_Buyer_Id = l.Login_Buyer_Id,
                Login_Id = l.Login_Id,
                Buyer_Id = l.Buyer_Id,
            });
        }
        public async Task<Login_Buyer_Response> GetLogin_BuyerById(int id)
        {
            var login_Buyer = await _context.LoginBuyers.FindAsync(id);
            if (login_Buyer == null)
            {
                return null;
            }
            return new Login_Buyer_Response
            {
                Login_Buyer_Id = login_Buyer.Login_Buyer_Id,
                Login_Id = login_Buyer.Login_Id,
                Buyer_Id = login_Buyer.Buyer_Id,
            };
        }
        public async Task<string> UpdateLogin_Buyer(int id, Login_Buyer_Request login_Buyer)
        {
            var existingLogin_Buyer = await _context.LoginBuyers.FindAsync(id);
            if (existingLogin_Buyer == null)
            {
                return "Login_Buyer not found";
            }
            existingLogin_Buyer.Login_Id = login_Buyer.Login_Id;
            existingLogin_Buyer.Buyer_Id = login_Buyer.Buyer_Id;
            await _context.SaveChangesAsync();
            return "Login_Buyer updated successfully";
        }
    
    }
}
