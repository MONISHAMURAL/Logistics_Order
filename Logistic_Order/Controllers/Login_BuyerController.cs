using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login_BuyerController : ControllerBase
    {
        private readonly ILogin_Buyer _login_BuyerServices;
        public Login_BuyerController(ILogin_Buyer login_BuyerServices)
        {
            _login_BuyerServices = login_BuyerServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLogin_Buyers()
        {
            try
            {
                var login_Buyers = await _login_BuyerServices.GetAllLogin_Buyers();
                return Ok(login_Buyers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin_BuyerById(int id)
        {
            try
            {
                var login_Buyer = await _login_BuyerServices.GetLogin_BuyerById(id);
                if (login_Buyer == null)
                {
                    return NotFound();
                }
                return Ok(login_Buyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLogin_Buyer([FromBody] Login_Buyer_Request login_Buyer)
        {
            try
            {
                var result = await _login_BuyerServices.CreateLogin_Buyer(login_Buyer);
                if (result == "Login_Buyer already exists")
                {
                    return Conflict(result);
                }
                return CreatedAtAction(nameof(GetLogin_BuyerById), new { id = login_Buyer.Login_Buyer_Id }, login_Buyer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogin_Buyer(int id, [FromBody] Login_Buyer_Request login_Buyer)
        {
            try
            {
                var result = await _login_BuyerServices.UpdateLogin_Buyer(id, login_Buyer);
                if (result == "Login_Buyer not found")
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin_Buyer(int id)
        {
            try
            {
                var result = await _login_BuyerServices.DeleteLogin_Buyer(id);
                if (result == "Login_Buyer not found")
                {
                    return NotFound(result);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
