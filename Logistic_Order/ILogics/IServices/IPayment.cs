using Logistic_Order.Request;
using Logistic_Order.Response;

namespace Logistic_Order.ILogics.IServices
{
    public interface IPayment
    {
        public  Task<string> AddPayment(Payment_Request payment);
        public  Task<Payment_Response> UpdatePayment(Payment_Request payment);
        public  Task<string> DeletePayment(int id);
        public  Task<string> GetPayment(int id);
        public  Task<List<Payment_Response>> GetAllPayments();


    }
}
