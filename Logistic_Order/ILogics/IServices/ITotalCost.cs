using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ITotalCost
    {
        Task<IEnumerable<TotalCostResponse>> GetAllTotalCostsAsync();
        Task<TotalCostResponse> GetTotalCostByIdAsync(int id);
        Task<string> CreateTotalCostAsync(TotalCost_Request totalCost);
        Task<TotalCostResponse> UpdateTotalCost(int id, TotalCost_Request totalCost);
        Task<bool> DeleteTotalCost(int id);
    }
}
