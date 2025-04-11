using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock_Controller : ControllerBase
    {
        private readonly IStockServices _stockServices;
        public Stock_Controller(IStockServices stockServices)
        {
            _stockServices = stockServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStocks()
        {
            var stocks = await _stockServices.GetAllStocksAsync();
            return Ok(stocks);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStockById(int id)
        {
            var stock = await _stockServices.GetStockByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] Stock_Request stock)
        {
            if (stock == null)
            {
                return BadRequest("Invalid stock data.");
            }
            var result = await _stockServices.CreateStockAsync(stock);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] Stock_Request stock)
        {
            if (stock == null)
            {
                return BadRequest("Invalid stock data.");
            }
            var result = await _stockServices.UpdateStock(id, stock);
            if (result == null)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            var result = await _stockServices.DeleteStock(id);
            if (!result)
            {
                return NotFound($"Stock with ID {id} not found.");
            }
            return NoContent();
        }


    }
}
