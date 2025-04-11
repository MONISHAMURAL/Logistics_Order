using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login_supplierController : ControllerBase
    {
        private readonly ILogin_Supplier _loginSupplierService;
        public Login_supplierController(ILogin_Supplier loginSupplierService)
        {
            _loginSupplierService = loginSupplierService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLoginSuppliers()
        {
            var result = await _loginSupplierService.GetAllLogin_Suppliers();
            if (result == null || !result.Any())
            {
                return NotFound("No login suppliers found.");
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetLoginSupplierById(int id)
        {
            var result = await _loginSupplierService.GetLogin_SupplierById(id);
            if (result == null)
            {
                return NotFound($"Login supplier with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateLoginSupplier([FromBody] Login_Supplier_Request loginSupplierRequest)
        {
            if (loginSupplierRequest == null)
            {
                return BadRequest("Invalid login supplier data.");
            }
            var result = await _loginSupplierService.CreateLogin_Supplier(loginSupplierRequest);
            if (result == null)
            {
                return BadRequest("Failed to create login supplier.");
            }
            return CreatedAtAction(nameof(GetLoginSupplierById), new { id = result }, result);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLoginSupplier(int id)
        {
            var result = await _loginSupplierService.DeleteLogin_Supplier(id);
            if (result == null)
            {
                return NotFound($"Login supplier with ID {id} not found.");
            }
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLoginSupplier(int id, [FromBody] Login_Supplier_Request loginSupplierRequest)
        {
            if (loginSupplierRequest == null)
            {
                return BadRequest("Invalid login supplier data.");
            }
            var result = await _loginSupplierService.UpdateLogin_Supplier(id, loginSupplierRequest);
            if (result == null)
            {
                return NotFound($"Login supplier with ID {id} not found.");
            }
            return Ok(result);
        }


    }
}
