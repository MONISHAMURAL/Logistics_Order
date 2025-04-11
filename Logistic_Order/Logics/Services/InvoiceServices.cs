using Logistic_Order.Data;
using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.EntityFrameworkCore;

namespace Logistic_Order.Logics.Services
{
    public class InvoiceServices:IInvoiceServices
    {
        private readonly LoginDbContext _context;
        public InvoiceServices(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Invoice_Response>> GetAllInvoices()
        {
            var invoices = await _context.Invoices.ToListAsync();
            return invoices.Select(i => new Invoice_Response
            {
                Invoice_No = i.Invoice_No,
                Invoice_Date = i.Invoice_Date,
                Invoice_Status = i.Invoice_Status,
                Invoice_Amount = i.Invoice_Amount,
                Order_No = i.Order_No,
                Payment_Id = i.Payment_Id,
                Shipping_Id = i.Shipping_Id
            });
        }
        public async Task<Invoice_Response> GetInvoiceById(int Invoice_No)
        {
            var invoice = await _context.Invoices.FindAsync(Invoice_No);
            if (invoice == null)
            {
                return null;
            }
            return new Invoice_Response
            {
                Invoice_No = invoice.Invoice_No,
                Invoice_Date = invoice.Invoice_Date,
                Invoice_Status = invoice.Invoice_Status,
                Invoice_Amount = invoice.Invoice_Amount,
                Order_No = invoice.Order_No,
                Payment_Id = invoice.Payment_Id,
                Shipping_Id = invoice.Shipping_Id
            };
        }
        public async Task<string> CreateInvoice(Invoice_Request invoice)
        {
            try
            {
                var existingInvoice = await _context.Invoices.FindAsync(invoice.Invoice_No);
                if (existingInvoice !=null)
                {
                    return "Invoice already exists";
                }
            
                var newInvoice = new Invoice
            {
                Invoice_No = invoice.Invoice_No,
                Invoice_Date = invoice.Invoice_Date,
                Invoice_Status = invoice.Invoice_Status,
                Invoice_Amount = invoice.Invoice_Amount,
                Order_No = invoice.Order_No,
                Payment_Id = invoice.Payment_Id,
                Shipping_Id = invoice.Shipping_Id
            };
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();
            return "Invoice created successfully";
        }
            catch (Exception ex)
            {
                return $"Error creating invoice: {ex.Message}";
            }
        }
        public async Task<Invoice_Response> UpdateInvoice(int Invoice_No, Invoice_Request invoice)
        {
            var existingInvoice = await _context.Invoices.FindAsync(Invoice_No);
            if (existingInvoice == null)
            {
                return null;
            }
            existingInvoice.Invoice_Date = invoice.Invoice_Date;
            existingInvoice.Invoice_Status = invoice.Invoice_Status;
            existingInvoice.Invoice_Amount = invoice.Invoice_Amount;
            existingInvoice.Order_No = invoice.Order_No;
            existingInvoice.Payment_Id = invoice.Payment_Id;
            existingInvoice.Shipping_Id = invoice.Shipping_Id;
            await _context.SaveChangesAsync();
            return new Invoice_Response
            {
                Invoice_No = existingInvoice.Invoice_No,
                Invoice_Date = existingInvoice.Invoice_Date,
                Invoice_Status = existingInvoice.Invoice_Status,
                Invoice_Amount = existingInvoice.Invoice_Amount,
                Order_No = existingInvoice.Order_No,
                Payment_Id = existingInvoice.Payment_Id,
                Shipping_Id = existingInvoice.Shipping_Id
            };
        }
        public async Task<bool> DeleteInvoice(int Invoice_No)
        {
            var invoice = await _context.Invoices.FindAsync(Invoice_No);
            if (invoice == null)
            {
                return false;
            }
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
