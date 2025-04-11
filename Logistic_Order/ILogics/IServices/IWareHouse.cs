using Logistic_Order.Request;

namespace Logistic_Order.ILogics.IServices
{
    public interface IWareHouse
    {
        Task<string>AddWareHouse(WareHouse_Request wareHouse_Request);
        Task<string> UpdateWareHouse(WareHouse_Request wareHouse_Request);
        Task<string> DeleteWareHouse(int id);
        Task<IEnumerable<WareHouse_Request>> GetWareHouse();
        Task<WareHouse_Request> GetWareHouseById(int id);

    }
}
