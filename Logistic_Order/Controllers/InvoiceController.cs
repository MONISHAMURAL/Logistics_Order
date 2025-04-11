using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceServices _invoiceServices;
        public InvoiceController(IInvoiceServices invoiceServices)
        {
            _invoiceServices = invoiceServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            try
            {
                var invoices = await _invoiceServices.GetAllInvoices();
                return Ok(invoices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{Invoice_No}")]
        public async Task<IActionResult> GetInvoiceById(int Invoice_No)
        {
            try
            {
                var invoice = await _invoiceServices.GetInvoiceById(Invoice_No);
                if (invoice == null)
                {
                    return NotFound();
                }
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice_Request invoice)
        {
            try
            {
                var result = await _invoiceServices.CreateInvoice(invoice);
                if (result == "Invoice already exists")
                {
                    return Conflict(result);
                }
                return CreatedAtAction(nameof(GetInvoiceById), new { Invoice_No = invoice.Invoice_No }, invoice);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{Invoice_No}")]
        public async Task<IActionResult> UpdateInvoice(int Invoice_No, [FromBody] Invoice_Request invoice)
        {
            try
            {
                var result = await _invoiceServices.UpdateInvoice(Invoice_No, invoice);
                if (result == null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{Invoice_No}")]
        public async Task<IActionResult> DeleteInvoice(int Invoice_No)
        {
            try
            {
                var result = await _invoiceServices.DeleteInvoice(Invoice_No);
                if(result==null)
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    }
