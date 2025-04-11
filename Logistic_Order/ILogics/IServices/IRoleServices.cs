using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IRoleServices
    {
        Task<List<Role_Response>> GetAllRoles();
        Task<Role_Response> GetRoleById(int id);
        Task<string> AddRole(Role_Request role);
        Task<Role_Response> UpdateRole(Role_Request role);
        Task<bool> DeleteRole(int id);
    }
}
