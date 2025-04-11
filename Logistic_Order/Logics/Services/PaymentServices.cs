using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class PaymentServices:IPayment
    {
        private readonly LoginDbContext _payment;
        public PaymentServices(LoginDbContext payment)
        {
            _payment = payment;
        }
        public async Task<string> AddPayment(Payment_Request payment)
        {
            try
            {
                var existingPayment = await _payment.Payments
                    .FirstOrDefaultAsync(p => p.Payment_Id == payment.Payment_Id);
                if (existingPayment != null)
                {
                    return "Payment already exists";
                }
                Payment newPayment = new Payment()
                {
                    Payment_Type = payment.Payment_Type,
                    Payment_Description = payment.Payment_Description,
                    Payment_Status = payment.Payment_Status,
                    Payment_Date = payment.Payment_Date,
                    Cost_Id = payment.Cost_Id,
                    Buyer_Id = payment.Buyer_Id,
                    Id=payment.Id,
                    Payment_Id=payment.Payment_Id
                    
                };
                 _payment.Payments.AddAsync(newPayment);
                await _payment.SaveChangesAsync();
                return "Payment added successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
        public async Task<Payment_Response> UpdatePayment(Payment_Request payment)
        {
            try
            {
                var res = await _payment.Payments.FindAsync(payment.Payment_Id);
                if (res == null)
                {
                    return null;
                }
                res.Payment_Type = payment.Payment_Type;
                res.Payment_Description = payment.Payment_Description;
                res.Payment_Status = payment.Payment_Status;
                res.Payment_Date = payment.Payment_Date;
                res.Cost_Id = payment.Cost_Id;
                res.Buyer_Id = payment.Buyer_Id;
                await _payment.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return new Payment_Response()
            {
                Payment_Id = payment.Payment_Id,
                Payment_Type = payment.Payment_Type,
                Payment_Description = payment.Payment_Description,
                Payment_Status = payment.Payment_Status,
                Payment_Date = payment.Payment_Date,
                Cost_Id = payment.Cost_Id,
                Buyer_Id = payment.Buyer_Id
            };
        }
        public async Task<string> DeletePayment(int id)
        {
            try
            {
                var res = await _payment.Payments.FindAsync(id);
                if (res == null)
                {
                    return "Payment not found";
                }
                _payment.Payments.Remove(res);
                await _payment.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Payment deleted successfully";
        }
        public async Task<string> GetPayment(int id)
        {
            try
            {
                var res = await _payment.Payments.FindAsync(id);
                if (res == null)
                {
                    return "Payment not found";
                }
                return res.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public async Task<List<Payment_Response>>GetAllPayments()
        {
            try
            {
                var res = await _payment.Payments.ToListAsync();
                if (res == null)
                {
                    return null;
                }
                var payments = res.Select(payment => new Payment_Response
                {
                    Payment_Id = payment.Payment_Id,
                    Payment_Type = payment.Payment_Type,
                    Payment_Description = payment.Payment_Description,
                    Payment_Status = payment.Payment_Status,
                    Payment_Date = payment.Payment_Date,
                    Cost_Id = payment.Cost_Id,
                    Buyer_Id = payment.Buyer_Id
                }).ToList();
                return payments;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
