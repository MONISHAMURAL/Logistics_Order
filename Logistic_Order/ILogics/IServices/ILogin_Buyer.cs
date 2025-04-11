using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ILogin_Buyer
    {
        Task<IEnumerable<Login_Buyer_Response>> GetAllLogin_Buyers();
        Task<Login_Buyer_Response> GetLogin_BuyerById(int id);
        Task<string> CreateLogin_Buyer(Login_Buyer_Request login_Buyer);
        Task<string> UpdateLogin_Buyer(int id, Login_Buyer_Request login_Buyer);
        Task<string> DeleteLogin_Buyer(int id);
    }
}
