using Logistic_Order.Logics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IBuyerServices _buyerServices;
        public BuyerController(IBuyerServices buyerServices)
        {
            _buyerServices = buyerServices;
        }
        [HttpPost("AddBuyers")]
        public async Task<IActionResult> AddBuyers([FromBody] Buyer_Request buyer_Request)
        {
            var result = await _buyerServices.AddBuyers(buyer_Request);
            if (result == "Buyer added successfully")
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut("UpdateBuyers")]
        public async Task<IActionResult> UpdateBuyers([FromBody] Buyer_Request buyer_Request)
        {
            var result = await _buyerServices.UpdateBuyers(buyer_Request);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Buyer not found");
        }
        [HttpGet("GetBuyers/{id}")]
        public async Task<IActionResult> GetBuyers(int id)
        {
            var result = await _buyerServices.GetBuyersById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("Buyer not found");
        }
        [HttpGet("GetAllBuyers")]
        public async Task<IActionResult> GetAllBuyers()
        {
            var result = await _buyerServices.GetAllBuyers();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound("No buyers found");
        }
        [HttpDelete("RemoveBuyers/{id}")]
        public async Task<IActionResult> RemoveBuyers(int id)
        {
            var result = await _buyerServices.RemoveBuyers(id);
            if (result)
            {
                return Ok("Buyer removed successfully");
            }
            return NotFound("Buyer not found");
        }
    }
}
