using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrder _orderService;
        public OrderController(IOrder orderService)
        {
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrders();
            return Ok(orders);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order_Request order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var result = await _orderService.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.Order_No }, result);
        }
           
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order_Request order)
        {
            if (order == null)
            {
                return BadRequest();
            }
            var result = await _orderService.UpdateOrder(id, order);
            if (result == "Order not found")
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (result == "Order not found")
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
