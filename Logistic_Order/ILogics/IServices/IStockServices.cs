using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IStockServices
    {
        Task<IEnumerable<Stock_Response>> GetAllStocksAsync();
        Task<Stock_Response> GetStockByIdAsync(int id);
        Task<string> CreateStockAsync(Stock_Request stock);
        Task<Stock_Response> UpdateStock(int id, Stock_Request stock);
        Task<bool> DeleteStock(int id);
    }
}
