using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class PermissionRole_Services : IPermissionRole
    {
        private readonly LoginDbContext _context;
        public PermissionRole_Services(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddPermissionRole(PermissionRole_Request permissionRole_Request)
        {
            try
            {
                var existingPermissionRole = await _context.PermissionRoles
                    .FirstOrDefaultAsync(p => p.Permission_Id == permissionRole_Request.Permission_Id);
                if (existingPermissionRole != null)
                {
                    return "Permission Role already exists";
                }
                PermissionRole permissionRole = new PermissionRole()
                {
                    Permission_Id = permissionRole_Request.Permission_Id,
                    Role_Id = permissionRole_Request.Role_Id,
                    Id = permissionRole_Request.Id
                };
                _context.PermissionRoles.Add(permissionRole);
                await _context.SaveChangesAsync();
                return "Permission Role added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<PermissionRole_Response> UpdatePermissionRole(PermissionRole_Request permissionRole_Request)
        {
            try
            {
                var permissionRole = await _context.PermissionRoles.FindAsync(permissionRole_Request.Permission_Id);
                if (permissionRole == null)
                {
                    return null;
                }
                permissionRole.Permission_Id = permissionRole_Request.Permission_Id;
                permissionRole.Role_Id = permissionRole_Request.Role_Id;
                _context.PermissionRoles.Update(permissionRole);
                await _context.SaveChangesAsync();
                return new PermissionRole_Response
                {
                    Id = permissionRole.Id,
                    Permission_Id = permissionRole.Id,
                    Role_Id = permissionRole.Role_Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> DeletePermissionRole(int id)
        {
            try
            {
                var permissionRole = await _context.PermissionRoles.FindAsync(id);
                if (permissionRole == null)
                {
                    return "Permission Role not found";
                }
                _context.PermissionRoles.Remove(permissionRole);
                await _context.SaveChangesAsync();
                return "Permission Role deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<PermissionRole_Response> GetPermissionRole(int id)
        {
            try
            {
                var permissionRole = await _context.PermissionRoles.FindAsync(id);
                if (permissionRole == null)
                {
                    return null;
                }
                return new PermissionRole_Response
                {
                    Permission_Id = permissionRole.Permission_Id,
                    Role_Id = permissionRole.Role_Id,
                    Id = permissionRole.Id
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<PermissionRole_Response>> GetAllPermissionRoles()
        {
            try
            {
                var permissionRoles = await _context.PermissionRoles.ToListAsync();
                return permissionRoles.Select(p => new PermissionRole_Response
                {
                    Permission_Id = p.Permission_Id,
                    Role_Id = p.Role_Id,
                    Id = p.Id
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
