using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface ICommodities_Category
    {
        Task<IEnumerable<Commodity_Category_Response>>GetCategory();
        Task<string>CreateCategory(Commodity_Category_Request request);
        Task<string>UpdateCategory(Commodity_Category_Request request);
        Task<bool>DeleteCategory(int categoryId);
        Task<Commodity_Category_Response>GetCategoryById(int  categoryId);


        
    }
}
