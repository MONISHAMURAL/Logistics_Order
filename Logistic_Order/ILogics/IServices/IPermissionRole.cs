using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IPermissionRole
    {
        Task<string> AddPermissionRole(PermissionRole_Request permissionRole_Request);
        Task<PermissionRole_Response> UpdatePermissionRole(PermissionRole_Request permissionRole_Request);
        Task<string> DeletePermissionRole(int id);
        Task<PermissionRole_Response> GetPermissionRole(int id);
        Task<List<PermissionRole_Response>> GetAllPermissionRoles();
    }
}
