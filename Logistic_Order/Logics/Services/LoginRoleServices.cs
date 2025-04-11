using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class LoginRoleServices : ILoginRole
    {
        private readonly LoginDbContext _context;
        public LoginRoleServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LoginRole_Response>> GetAllLoginRoles()
        {
            try
            {
                var loginRoles = await _context.LoginRoles.ToListAsync();
                List<LoginRole_Response> loginRoleResponses = new List<LoginRole_Response>();
                foreach (var loginRole in loginRoles)
                {
                    loginRoleResponses.Add(new LoginRole_Response
                    {
                        Login_Role_Id = loginRole.Login_Role_Id,
                        Login_Id = loginRole.Login_Id,
                        Role_Id = loginRole.Role_Id,
                    });
                }
                return loginRoleResponses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<LoginRole_Response> GetLoginRoleById(int id)
        {
            try
            {
                var loginRole = await _context.LoginRoles.FindAsync(id);
                if (loginRole == null)
                {
                    return null;
                }
                return new LoginRole_Response
                {
                    Login_Role_Id = loginRole.Login_Role_Id,
                    Login_Id = loginRole.Login_Id,
                    Role_Id = loginRole.Role_Id,
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public async Task<string> CreateLoginRole(LoginRole_Request loginRole)
        {
            try
            {
                Login_Role newLoginRole = new Login_Role
                {
                    Login_Role_Id = loginRole.Login_Role_Id,
                    Login_Id = loginRole.Login_Id,
                    Role_Id = loginRole.Role_Id,
                };
                await _context.LoginRoles.AddAsync(newLoginRole);
                await _context.SaveChangesAsync();
                return "Login Role created successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error creating Login Role";
            }
        }
        public async Task<string> UpdateLoginRole(int id, Login_Role loginRole)
        {
            try
            {
                var existingLoginRole = await _context.LoginRoles.FindAsync(id);
                if (existingLoginRole == null)
                {
                    return "Login Role not found";
                }
                existingLoginRole.Login_Id = loginRole.Login_Id;
                existingLoginRole.Role_Id = loginRole.Role_Id;
                await _context.SaveChangesAsync();
                return "Login Role updated successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error updating Login Role";
            }
        }
        public async Task<string> DeleteLoginRole(int id)
        {
            try
            {
                var loginRole = await _context.LoginRoles.FindAsync(id);
                if (loginRole == null)
                {
                    return "Login Role not found";
                }
                _context.LoginRoles.Remove(loginRole);
                await _context.SaveChangesAsync();
                return "Login Role deleted successfully";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "Error deleting Login Role";
            }
        }
    }
}
