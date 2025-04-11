using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalCost_Controller : ControllerBase
    {
        private readonly ITotalCost _totalCostServices;
        public TotalCost_Controller(ITotalCost totalCostServices)
        {
            _totalCostServices = totalCostServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTotalCosts()
        {
            var totalCosts = await _totalCostServices.GetAllTotalCostsAsync();
            return Ok(totalCosts);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTotalCostById(int id)
        {
            var totalCost = await _totalCostServices.GetTotalCostByIdAsync(id);
            if (totalCost == null)
            {
                return NotFound();
            }
            return Ok(totalCost);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTotalCost([FromBody] TotalCost_Request totalCost)
        {
            if (totalCost == null)
            {
                return BadRequest("Invalid total cost data.");
            }
            var result = await _totalCostServices.CreateTotalCostAsync(totalCost);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTotalCost(int id, [FromBody] TotalCost_Request totalCost)
        {
            if (totalCost == null)
            {
                return BadRequest("Invalid total cost data.");
            }
            var updatedTotalCost = await _totalCostServices.UpdateTotalCost(id, totalCost);
            if (updatedTotalCost == null)
            {
                return NotFound();
            }
            return Ok(updatedTotalCost);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTotalCost(int id)
        {
            var result = await _totalCostServices.DeleteTotalCost(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
