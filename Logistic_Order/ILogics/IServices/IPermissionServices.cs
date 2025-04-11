using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IPermissionServices
    {
        Task<string> AddPermission(PermissionRequest permission_Request);
        Task<Permission_Response> UpdatePermission(PermissionRequest permission_Request);
        Task<string> DeletePermission(int id);
        Task<Permission_Response> GetPermission(int id);
        Task<List<Permission_Response>> GetAllPermissions();

    }
}
