using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly LoginDbContext _context;
        public LoginServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<Login_Response> GetLoginById(int id)
        {
            var login = await _context.Logins.FindAsync(id);
            if (login == null)
            {
                return null;
            }
            return new Login_Response
            {
               
                Login_Id = login.Login_Id,
                Username = login.Username,
                Password = login.Password
            };
        }
        public async Task<IEnumerable<Login_Response>> GetAllLogins()
        {
            var logins = await _context.Logins.ToListAsync();
            return logins.Select(l => new Login_Response
            {
                Login_Id = l.Login_Id,
                Username = l.Username,
                Password = l.Password
            });
        }
        public async Task<string> CreateLogin(Login_Response login)
        {
            try
            {
                var existingLogin = await _context.Logins.FindAsync(login.Login_Id);
                if (existingLogin != null)
                {
                    return "Login already exists";
                }

                var newLogin = new Login
                {
                    Login_Id = login.Login_Id,
                    Username = login.Username,
                    Password = login.Password
                };
                _context.Logins.Add(newLogin);
                await _context.SaveChangesAsync();
                return "Login created successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> UpdateLogin(int id, Login_Response login)
        {
            try
            {
                var existingLogin = await _context.Logins.FindAsync(id);
                if (existingLogin == null)
                {
                    return "Login not found";
                }
                existingLogin.Username = login.Username;
                existingLogin.Password = login.Password;
                _context.Logins.Update(existingLogin);
                await _context.SaveChangesAsync();
                return "Login updated successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<string> DeleteLogin(int id)
        {
            try
            {
                var existingLogin = await _context.Logins.FindAsync(id);
                if (existingLogin == null)
                {
                    return "Login not found";
                }
                _context.Logins.Remove(existingLogin);
                await _context.SaveChangesAsync();
                return "Login deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}