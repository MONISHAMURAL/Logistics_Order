using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCommodities_Controller : ControllerBase
    {
        private readonly IOrderCommodities _orderCommoditiesService;
        public OrderCommodities_Controller(IOrderCommodities orderCommoditiesService)
        {
            _orderCommoditiesService = orderCommoditiesService;
        }
        [HttpPost("CreateOrderCommodities")]
        public async Task<IActionResult> CreateOrderCommodities([FromBody] OrderCommodities_Request orderCommodities)
        {
            try
            {
                if (orderCommodities == null)
                {
                    return BadRequest("Order commodities request cannot be null");
                }
                var result = await _orderCommoditiesService.CreateOrderCommoditiesAsync(orderCommodities);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOrderCommodities")]
        public async Task<IActionResult>Update([FromBody] OrderCommodities_Request orderCommodities)
        {
            try
            {
                if (orderCommodities == null)
                {
                    return BadRequest("Order commodities request cannot be null");
                }
                var result = await _orderCommoditiesService.UpdateOrderCommoditiesAsync(orderCommodities);
                if (result == null)
                {
                    return NotFound($"Order commodities with ID {orderCommodities.Order_No} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOrderCommodities/{id}")]
        public async Task<IActionResult> DeleteOrderCommodities(int id)
        {
            try
            {
                var result = await _orderCommoditiesService.DeleteOrderCommoditiesAsync(id);
                if (!result)
                {
                    return NotFound($"Order commodities with ID {id} not found");
                }
                return Ok("Order commodities deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetOrderCommoditiesId/{id}")]
        public async Task<IActionResult> GetOrderCommoditiesId(int id)
        {
            try
            {
                var result = await _orderCommoditiesService.GetOrderCommoditiesIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Order commodities with ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetAllOrderCommodities")]
        public async Task<IActionResult> GetAllOrderCommodities()
        {
            try
            {
                var result = await _orderCommoditiesService.GetAllOrderCommoditiesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }

    }
}
