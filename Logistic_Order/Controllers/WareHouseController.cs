using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
       private readonly IWareHouse _wareHouseServices;
        public WareHouseController(IWareHouse wareHouseServices)
        {
            _wareHouseServices = wareHouseServices;
        }
        [HttpPost("AddWareHouse")]
        public async Task<IActionResult> AddWareHouse([FromBody] WareHouse_Request wareHouse_Request)
        {
            var result = await _wareHouseServices.AddWareHouse(wareHouse_Request);
            return Ok(result);
        }
        [HttpPut("UpdateWareHouse")]
        public async Task<IActionResult> UpdateWareHouse([FromBody] WareHouse_Request wareHouse_Request)
        {
            var result = await _wareHouseServices.UpdateWareHouse(wareHouse_Request);
            return Ok(result);
        }
        [HttpDelete("DeleteWareHouse/{id}")]
        public async Task<IActionResult> DeleteWareHouse(int id)
        {
            var result = await _wareHouseServices.DeleteWareHouse(id);
            return Ok(result);
        }
        [HttpGet("GetWareHouses")]
        public async Task<IActionResult> GetWareHouses()
        {
            var result = await _wareHouseServices.GetWareHouse();
            return Ok(result);
        }
        [HttpGet("GetWareHousesById/{id}")]
        public async Task<IActionResult> GetWareHousesById(int id)
        {
            var result = await _wareHouseServices.GetWareHouseById(id);
            return Ok(result);
        }
    }
}
