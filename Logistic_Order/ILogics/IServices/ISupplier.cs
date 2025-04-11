using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ISupplier
    {
        Task<IEnumerable<Supplier_Response>> GetAllSuppliers();
        Task<Supplier_Response> GetSupplierById(int id);
        Task<string> AddSupplier(Supplier_Request supplier);
        Task<Supplier_Response> UpdateSupplier(Supplier_Request supplier);
        Task<bool> DeleteSupplier(int id);
    }
}
