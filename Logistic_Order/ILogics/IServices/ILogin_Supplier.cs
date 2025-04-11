using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ILogin_Supplier
    {
        Task<IEnumerable<Login_Supplier_Response>> GetAllLogin_Suppliers();
        Task<Login_Supplier_Response> GetLogin_SupplierById(int id);
        Task<string> CreateLogin_Supplier(Login_Supplier_Request login_Supplier);
        Task<string> UpdateLogin_Supplier(int id, Login_Supplier_Request login_Supplier);
        Task<string> DeleteLogin_Supplier(int id);
    }
}
