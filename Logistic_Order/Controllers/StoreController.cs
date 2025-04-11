using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStore _storeServices;
        public StoreController(IStore storeServices)
        {
            _storeServices = storeServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeServices.GetAllStoresAsync();
            return Ok(stores);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var store = await _storeServices.GetStoreByIdAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] Store_Request store)
        {
            if (store == null)
            {
                return BadRequest("Invalid store data.");
            }
            var result = await _storeServices.CreateStoreAsync(store);
            return Ok(result);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] Store_Request store)
        {
            if (store == null)
            {
                return BadRequest("Invalid store data.");
            }
            var updatedStore = await _storeServices.UpdateStore(id, store);
            if (updatedStore == null)
            {
                return NotFound();
            }
            return Ok(updatedStore);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _storeServices.DeleteStore(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok("Store deleted successfully");
        }
    }

}
