using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ICommodityServices
    {
        Task<List<Commodity_Response>> GetAllCommodities();
        Task<Commodity_Response> GetCommodityById(int id);
        Task<string> AddCommodity(Commodity_Request commodity);
        Task<Commodity_Response> UpdateCommodity(Commodity_Request commodity);
        Task<bool> DeleteCommodity(int id);
       
    }
}
