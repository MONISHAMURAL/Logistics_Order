using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly IDeliveryServices _deliveryServices;
        public DeliveryController(IDeliveryServices deliveryServices)
        {
            _deliveryServices = deliveryServices;
        }
        [HttpPost("AddDelivery")]
        public async Task<IActionResult> AddDelivery([FromBody] DeliveryRequest deliveryRequest)
        {
            var result = await _deliveryServices.AddDelivery(deliveryRequest);
            return Ok(result);
        }
        [HttpPut("UpdateDelivery/{id}")]
        public async Task<IActionResult> UpdateDelivery(int id, [FromBody] DeliveryRequest deliveryRequest)
        {
            var result = await _deliveryServices.UpdateDelivery(id, deliveryRequest);
            return Ok(result);
        }
        [HttpDelete("DeleteDelivery/{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var result = await _deliveryServices.DeleteDelivery(id);
            return Ok(result);
        }
        [HttpGet("GetAllDeliveries")]
        public async Task<IActionResult> GetAllDeliveries()
        {
            var result = await _deliveryServices.GetAllDelivery();
            return Ok(result);
        }
        [HttpGet("GetDeliveryById/{id}")]
        public async Task<IActionResult> GetDeliveryById(int id)
        {
            var result = await _deliveryServices.GetDeliveryById(id);
            return Ok(result);
        }
    }
}
