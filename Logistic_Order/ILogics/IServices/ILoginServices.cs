using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ILoginServices
    {
        Task<Login_Response>GetLoginById(int id);
        Task<IEnumerable<Login_Response>> GetAllLogins();
        Task<string> CreateLogin(Login_Response login);
        Task<string> UpdateLogin(int id, Login_Response login);
        Task<string> DeleteLogin(int id);
        
    }
}
