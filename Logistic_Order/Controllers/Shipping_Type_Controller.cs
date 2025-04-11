using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Logistic_Order.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Shipping_Type_Controller : ControllerBase
    {
        private readonly IShippingType shippingTypeService;
        public Shipping_Type_Controller(IShippingType shippingTypeService)
        {
            this.shippingTypeService = shippingTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShippingTypes()
        {
            var shippingTypes = await shippingTypeService.GetShippingTypeAsync();
            return Ok(shippingTypes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingTypeById(int id)
        {
            var shippingType = await shippingTypeService.GetShippingTypeByIdAsync(id);
            if (shippingType == null)
            {
                return NotFound();
            }
            return Ok(shippingType);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShippingType([FromBody] ShippingType_Request shippingType)
        {
            if (shippingType == null)
            {
                return BadRequest("Invalid shipping type data.");
            }
            var result = await shippingTypeService.CreateShippingTypeAsync(shippingType);
            return CreatedAtAction(nameof(GetShippingTypeById), new { id = result }, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShippingType(int id, [FromBody] Shipping_Type_Response shippingType)
        {
            if (shippingType == null)
            {
                return BadRequest("Invalid shipping type data.");
            }
            var result = await shippingTypeService.UpdateShippingTypeAsync(id, shippingType);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingType(int id)
        {
            var result = await shippingTypeService.DeleteShippingTypeAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
