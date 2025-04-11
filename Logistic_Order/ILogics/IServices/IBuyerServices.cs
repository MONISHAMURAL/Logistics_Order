using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.Logics.IServices
{
    public interface IBuyerServices
    {
        Task <string>AddBuyers(Buyer_Request buyer_Request);
        Task<Buyer_Response> UpdateBuyers(Buyer_Request buyer_Request);
        Task<Buyer_Response> GetBuyersById(int id);
        Task<List<Buyer_Response>> GetAllBuyers();
        Task <bool> RemoveBuyers(int id);
    }
}
