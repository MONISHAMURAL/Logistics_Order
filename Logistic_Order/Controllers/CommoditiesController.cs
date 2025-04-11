using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommoditiesController : ControllerBase
    {
        private readonly ICommodityServices _commodityServices;
        public CommoditiesController(ICommodityServices commodityServices)
        {
            _commodityServices = commodityServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var commodities = await _commodityServices.GetAllCommodities();
                return Ok(commodities);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var commodity = await _commodityServices.GetCommodityById(id);
                return Ok(commodity);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Commodity_Request commodity)
        {
            try
            {
                var result = await _commodityServices.AddCommodity(commodity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Commodity_Request commodity)
        {
            try
            {
                var result = await _commodityServices.UpdateCommodity(commodity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _commodityServices.DeleteCommodity(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
        }
