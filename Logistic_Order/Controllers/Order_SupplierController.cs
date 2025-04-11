using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_SupplierController : ControllerBase
    {
        private readonly IOrderSupplier _orderSupplierService;
        public Order_SupplierController(IOrderSupplier orderSupplierService)
        {
            _orderSupplierService = orderSupplierService;
        }
        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] Order_Supplier_Request order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order request cannot be null");
                }
                var result = await _orderSupplierService.CreateOrderAsync(order);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order_Supplier_Request order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Order request cannot be null");
                }
                var result = await _orderSupplierService.UpdateOrderAsync(order);
                if (result == null)
                {
                    return NotFound($"Order with ID {order.Order_No} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                var result = await _orderSupplierService.DeleteOrderAsync(id);
                if (!result)
                {
                    return NotFound($"Order with ID {id} not found");
                }
                return Ok("Order deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetOrderId/{id}")]
        public async Task<IActionResult> GetOrderId(int id)
        {
            try
            {
                var result = await _orderSupplierService.GetOrderIdAsync(id);
                if (result == null)
                {
                    return NotFound($"Order with ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var result = await _orderSupplierService.GetAllOrdersAsync();
                if (result == null || !result.Any())
                {
                    return NotFound("No orders found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        }
}
