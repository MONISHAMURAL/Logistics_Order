using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class RoleServices:IRoleServices
    {
        private readonly LoginDbContext loginDbContext;
        public RoleServices(LoginDbContext loginDbContext)
        {
            this.loginDbContext = loginDbContext;
        }
        public async Task<List<Role_Response>> GetAllRoles()
        {
            var roles = await loginDbContext.Roles.ToListAsync();
            return roles.Select(role => new Role_Response
            {
                Role_Id = role.Role_Id,
                Role_Name = role.Role_Name,
                Role_Description = role.Role_Description
            }).ToList();
        }
        public async Task<Role_Response> GetRoleById(int id)
        {
            var role = await loginDbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return null;
            }
            return new Role_Response
            {
                Role_Id = role.Role_Id,
                Role_Name = role.Role_Name,
                Role_Description = role.Role_Description
            };
        }
        public async Task<string> AddRole(Role_Request role)
        {
            var newRole = new Role
            {
                Role_Name = role.Role_Name,
                Role_Description = role.Role_Description
            };
            await loginDbContext.Roles.AddAsync(newRole);
            await loginDbContext.SaveChangesAsync();
            return "Role added successfully";
        }
        public async Task<Role_Response> UpdateRole(Role_Request role)
        {
            var existingRole = await loginDbContext.Roles.FindAsync(role.Role_Id);
            if (existingRole == null)
            {
                return null;
            }
            existingRole.Role_Name = role.Role_Name;
            existingRole.Role_Description = role.Role_Description;
            await loginDbContext.SaveChangesAsync();
            return new Role_Response
            {
                Role_Id = existingRole.Role_Id,
                Role_Name = existingRole.Role_Name,
                Role_Description = existingRole.Role_Description
            };
        }
        public async Task<bool> DeleteRole(int id)
        {
            var role = await loginDbContext.Roles.FindAsync(id);
            if (role == null)
            {
                return false;
            }
            loginDbContext.Roles.Remove(role);
            await loginDbContext.SaveChangesAsync();
            return true;
        }
    }
}
