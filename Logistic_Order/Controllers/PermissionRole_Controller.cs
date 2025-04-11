using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionRole_Controller : ControllerBase
    {
        private readonly IPermissionRole _permissionRole;
        public PermissionRole_Controller(IPermissionRole permissionRole)
        {
            _permissionRole = permissionRole;
        }
        [HttpPost("AddPermissionRole")]
        public async Task<IActionResult> AddPermissionRole([FromBody] PermissionRole_Request permissionRole_Request)
        {
            try
            {
                var result = await _permissionRole.AddPermissionRole(permissionRole_Request);
                if (result == "Permission Role added successfully")
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdatePermissionRole")]
        public async Task<IActionResult> UpdatePermissionRole([FromBody] PermissionRole_Request permissionRole_Request)
        {
            try
            {
                var result = await _permissionRole.UpdatePermissionRole(permissionRole_Request);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Permission Role not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletePermissionRole/{id}")]
        public async Task<IActionResult> DeletePermissionRole(int id)
        {
            try
            {
                var result = await _permissionRole.DeletePermissionRole(id);
                if (result == "Permission Role deleted successfully")
                {
                    return Ok(result);
                }
                return NotFound(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPermissionRole/{id}")]
        public async Task<IActionResult> GetPermissionRole(int id)
        {
            try
            {
                var result = await _permissionRole.GetPermissionRole(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Permission Role not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllPermissionRoles")]
        public async Task<IActionResult> GetAllPermissionRoles()
        {
            try
            {
                var result = await _permissionRole.GetAllPermissionRoles();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("No Permission Roles found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
