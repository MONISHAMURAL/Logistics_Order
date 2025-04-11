using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ILoginRole
    {
        Task<IEnumerable<LoginRole_Response>> GetAllLoginRoles();
        Task<LoginRole_Response> GetLoginRoleById(int id);
        Task<string> CreateLoginRole(LoginRole_Request loginRole);
        Task<string> UpdateLoginRole(int id, Login_Role loginRole);
        Task<string> DeleteLoginRole(int id);
    }
}
