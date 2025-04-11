using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IInvoiceServices
    {
        Task<IEnumerable<Invoice_Response>> GetAllInvoices();
        Task<Invoice_Response> GetInvoiceById(int Invoice_No);
        Task<string> CreateInvoice(Invoice_Request invoice);
        Task<Invoice_Response> UpdateInvoice(int Invoice_No, Invoice_Request invoice);
        Task<bool> DeleteInvoice(int Invoice_No);
    }
}
