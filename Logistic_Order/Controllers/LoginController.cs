using Logistic_Order.ILogics.IServices;
using Logistic_Order.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLogins()
        {
            try
            {
                var logins = await _loginServices.GetAllLogins();
                return Ok(logins);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public
            async Task<IActionResult> GetLoginById(int id)
        {
            try
            {
                var login = await _loginServices.GetLoginById(id);
                if (login == null)
                {
                    return NotFound();
                }
                return Ok(login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLogin([FromBody] Login_Response login)
        {
            try
            {
                var result = await _loginServices.CreateLogin(login);
                if (result == "Login already exists")
                {
                    return Conflict(result);
                }
                return CreatedAtAction(nameof(GetLoginById), new { id = login.Login_Id }, login);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogin(int id, [FromBody] Login_Response login)
        {
            try
            {
                var result = await _loginServices.UpdateLogin(id, login);
                if (result == "Login not found")
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
        public async Task<IActionResult> DeleteLogin(int id)
        {
            try
            {
                var result = await _loginServices.DeleteLogin(id);
                if (result == "Login not found")
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
