using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IStore
    {
        Task<IEnumerable<Store_Response>> GetAllStoresAsync();
        Task<Store_Response> GetStoreByIdAsync(int id);
        Task<string> CreateStoreAsync(Store_Request store);
        Task<Store_Response> UpdateStore(int id, Store_Request store);
        Task<bool> DeleteStore(int id);
    }
}
