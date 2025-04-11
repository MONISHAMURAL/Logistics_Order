using Logistic_Order.ILogics.IServices;
using Logistic_Order.Model.Entities;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginRoleController : ControllerBase
    {
        private readonly ILoginRole _loginRoleService;
        public LoginRoleController(ILoginRole loginRoleService)
        {
            _loginRoleService = loginRoleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLoginRoles()
        {
            var result = await _loginRoleService.GetAllLoginRoles();
            if (result == null || !result.Any())
            {
                return NotFound("No login roles found.");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLoginRoleById(int id)
        {
            var result = await _loginRoleService.GetLoginRoleById(id);
            if (result == null)
            {
                return NotFound($"Login role with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LoginRole_Request loginRole)
        {
            if (loginRole == null)
            {
                return BadRequest("Invalid login role data.");
            }
            var result = await _loginRoleService.CreateLoginRole(loginRole);
            if (result == null)
            {
                return BadRequest("Failed to create login role.");
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Login_Role loginRole)
        {
            if (loginRole == null)
            {
                return BadRequest("Invalid login role data.");
            }
            var result = await _loginRoleService.UpdateLoginRole(id, loginRole);
            if (result == null)
            {
                return NotFound($"Login role with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _loginRoleService.DeleteLoginRole(id);
            if (result == null)
            {
                return NotFound($"Login role with ID {id} not found.");
            }
            return Ok(result);
        }
        }
}
