using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionServices _permissionServices;
        public PermissionController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }
        [HttpPost("AddPermission")]
        public async Task<IActionResult> AddPermission([FromBody] PermissionRequest permission_Request)
        {
            try
            {
                var result = await _permissionServices.AddPermission(permission_Request);
                if (result == "Permission added successfully")
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
        [HttpPut("UpdatePermission")]
        public async Task<IActionResult> UpdatePermission([FromBody] PermissionRequest permission_Request)
        {
            try
            {
                var result = await _permissionServices.UpdatePermission(permission_Request);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Permission not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeletePermission/{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            try
            {
                var result = await _permissionServices.DeletePermission(id);
                if (result == "Permission deleted successfully")
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
        [HttpGet("GetPermission/{id}")]
        public async Task<IActionResult> GetPermission(int id)
        {
            try
            {
                var result = await _permissionServices.GetPermission(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("Permission not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllPermissions")]
        public async Task<IActionResult> GetAllPermissions()
        {
            try
            {
                var result = await _permissionServices.GetAllPermissions();
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound("No permissions found");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
