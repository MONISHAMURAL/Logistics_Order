using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplier _supplierService;
        public SupplierController(ISupplier supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("GetAllSuppliers")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var suppliers = await _supplierService.GetAllSuppliers();
                if (suppliers == null)
                {
                    return NotFound("No suppliers found");
                }
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                return BadRequest("Error retrieving suppliers: " + ex.Message);
            }
        }
        [HttpGet("GetSupplierById/{id}")]
        public async Task <IActionResult> GetId(int id)
        {
            try
            {
                var supplier =await _supplierService.GetSupplierById(id);
                if (supplier == null)
                {
                    return NotFound("Supplier not found");
                }
                return Ok(supplier);
            }
            catch (Exception ex)
            {
                return BadRequest("Error retrieving supplier: " + ex.Message);
            }
        }
        [HttpPost("AddSupplier")]
        public async Task<IActionResult> Post([FromBody] Supplier_Request supplier)
        {
            try
            {
                var result = await _supplierService.AddSupplier(supplier);
                if (result == null)
                {
                    return BadRequest("Error adding supplier");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error adding supplier: " + ex.Message);
            }
        }
        [HttpPut("UpdateSupplier")]
        public async Task <IActionResult> Put([FromBody] Supplier_Request supplier)
        {
            try
            {
                var result = await _supplierService.UpdateSupplier(supplier);
                if (result == null)
                {
                    return NotFound("Supplier not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error updating supplier: " + ex.Message);
            }
        }
        [HttpDelete("DeleteSupplier/{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            try
            {
                var result = await _supplierService.DeleteSupplier(id);
                return Ok("Supplier deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Error deleting supplier: " + ex.Message);
            }
        }
    }
    }
