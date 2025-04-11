using System.Security;
using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class PermissionServices : IPermissionServices
    {
        private readonly LoginDbContext _context;
        public PermissionServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddPermission(PermissionRequest permission_Request)
        {
            try
            {
                var existingPermission = await _context.Permissions
                    .FirstOrDefaultAsync(p => p.Permission_Id == permission_Request.Permission_Id);
                if (existingPermission != null)
                {
                    return "Permission already exists";
                }
                Permissions permission = new Permissions()
                {
                    Permission_Id = permission_Request.Permission_Id,
                    Permission_Type = permission_Request.Permission_Type,
                    Id = permission_Request.Id

                };
                _context.Permissions.Add(permission);
                await _context.SaveChangesAsync();
                return "Permission added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Permission_Response> UpdatePermission(PermissionRequest permission_Request)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(permission_Request.Permission_Id);
                if (permission == null)
                {
                    return null;
                }
                permission.Permission_Type = permission_Request.Permission_Type;
                permission.Id = permission_Request.Id;
                _context.Permissions.Update(permission);
                await _context.SaveChangesAsync();
                return new Permission_Response
                {
                    Permission_Id = permission.Permission_Id,
                    Permission_Type = permission.Permission_Type,
                    Id = permission.Id
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<string> DeletePermission(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);
                if (permission == null)
                {
                    return "Permission not found";
                }
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
                return "Permission deleted successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<Permission_Response> GetPermission(int id)
        {
            try
            {
                var permission = await _context.Permissions.FindAsync(id);
                if (permission == null)
                {
                    return null;
                }
                return new Permission_Response
                {
                    Permission_Id = permission.Permission_Id,
                    Permission_Type = permission.Permission_Type,
                    Id = permission.Id
                };

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<List<Permission_Response>> GetAllPermissions()
        {
            try
            {
                var permissions = await _context.Permissions.ToListAsync();
                return permissions.Select(l => new Permission_Response
                {
                    Permission_Id = l.Permission_Id,
                    Permission_Type = l.Permission_Type,
                    Id = l.Id
                }).ToList();

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
