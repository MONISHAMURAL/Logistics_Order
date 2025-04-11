using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }
        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleServices.GetAllRoles();
            return Ok(roles);
        }
        [HttpGet("GetRoleById/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _roleServices.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] Role_Request role)
        {
            if (role == null)
            {
                return BadRequest("Role cannot be null");
            }
            var result = await _roleServices.AddRole(role);
            return Ok(result);
        }
        [HttpPut("UpdateRole")]
        public async Task<IActionResult> UpdateRole([FromBody] Role_Request role)
        {
            if (role == null)
            {
                return BadRequest("Role cannot be null");
            }
            var updatedRole = await _roleServices.UpdateRole(role);
            if (updatedRole == null)
            {
                return NotFound();
            }
            return Ok(updatedRole);
        }
        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleServices.DeleteRole(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Role deleted successfully");
        }
    }
}
