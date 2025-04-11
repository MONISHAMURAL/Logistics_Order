using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Commodity_categories_Controller : ControllerBase
    {
        private readonly ICommodities_Category _categoryService;
        public Commodity_categories_Controller(ICommodities_Category categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetCategory()
        {
            try
            {
                var categories = await _categoryService.GetCategory();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromBody] Commodity_Category_Request request)
        {
            try
            {
                var result = await _categoryService.CreateCategory(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromBody] Commodity_Category_Request request)
        {
            try
            {
                var result = await _categoryService.UpdateCategory(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("DeleteCategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            try
            {
                var result = await _categoryService.DeleteCategory(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCategoryById/{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            try
            {
                var category = await _categoryService.GetCategoryById(categoryId);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
