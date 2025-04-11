using Logistic_Order.ILogics.IServices;
using Logistic_Order.Logics.Services;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayment _paymentServices;
        public PaymentController(IPayment paymentServices)
        {
            _paymentServices = paymentServices;
        }
        [HttpPost("AddPayment")]
        public async Task<IActionResult> AddPayment([FromBody] Payment_Request payment)
        {
            try
            {
                var result = await _paymentServices.AddPayment(payment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePayment")]
        public async Task<IActionResult> UpdatePayment([FromBody] Payment_Request payment)
        {
            try
            {
                var result = await _paymentServices.UpdatePayment(payment);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletePayment/{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            try
            {
                var result = await _paymentServices.DeletePayment(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("GetPayment/{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            try
            {
                var result = await _paymentServices.GetPayment(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
            [HttpGet("GetAllPayments")]
            public async Task<IActionResult> GetAllPayments()
            {
                try
                {
                    var result = await _paymentServices.GetAllPayments();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
       }
    }

