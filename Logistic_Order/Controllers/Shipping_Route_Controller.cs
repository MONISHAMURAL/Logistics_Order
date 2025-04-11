using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Shipping_Route_Controller : ControllerBase
    {
        private readonly IShipping_Route shippingRouteService;
        public Shipping_Route_Controller(IShipping_Route shippingRouteService)
        {
            this.shippingRouteService = shippingRouteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllShippingRoutes()
        {
            var routes = await shippingRouteService.GetAllShippingRoutesAsync();
            return Ok(routes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShippingRouteById(int id)
        {
            var route = await shippingRouteService.GetShippingRouteByIdAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            return Ok(route);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShippingRoute([FromBody] Shipping_Route_Request shippingRoute)
        {
            if (shippingRoute == null)
            {
                return BadRequest("Invalid shipping route data.");
            }
            var result = await shippingRouteService.CreateShippingRouteAsync(shippingRoute);
            return CreatedAtAction(nameof(GetShippingRouteById), new { id = result }, result);
        }
        [HttpPut("{id}")]
        public  async Task<IActionResult> UpdateShippingRoutes(int id, [FromBody] Shipping_Route_Request shippingRoute)
        {
            if (shippingRoute == null)
            {
                return BadRequest("Invalid shipping route data.");
            }
            var result = await shippingRouteService.UpdateShippingRoute(id,shippingRoute);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShippingRoute(int id)
        {
            var result = await shippingRouteService.DeleteShippingRoute(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
