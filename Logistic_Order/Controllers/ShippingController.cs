using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController(IShippingServices shippingServices) : ControllerBase
    {
        private readonly IShippingServices _shippingServices = shippingServices;

        [HttpGet("GetAllShipping")]
        public async Task<IActionResult> GetAllShipping()
        {
            try
            {
                var result = await _shippingServices.GetAllShipping();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet("GetShippingById/{id}")]
        public async Task<IActionResult> GetShippingById(int id)
        {
            try
            {
                var result = await _shippingServices.GetShippingById(id);
                if (result == null)
                {
                    return NotFound(new { message = "Shipping not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost("AddShipping")]
        public async Task<IActionResult> AddShipping([FromBody] Shipping_Request request)
        {
            try
            {
                var result = await _shippingServices.AddShipping(request);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("UpdateShipping")]
        public async Task<IActionResult> UpdateShipping([FromBody] Shipping_Request request)
        {
            try
            {
                var result = await _shippingServices.UpdateShipping(request);
                if (result == null)
                {
                    return NotFound(new { message = "Shipping not found" });
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("DeleteShipping/{id}")]
        public async Task<IActionResult> DeleteShipping(int id)
        {
            try
            {
                var result = await _shippingServices.DeleteShipping(id);
                if (!result)
                {
                    return NotFound(new { message = "Shipping not found" });
                }
                return Ok(new { message = "Shipping deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
