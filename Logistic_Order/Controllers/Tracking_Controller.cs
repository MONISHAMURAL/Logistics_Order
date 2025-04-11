using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tracking_Controller : ControllerBase
    {
        private readonly ITracking_Services _trackingServices;
        public Tracking_Controller(ITracking_Services trackingServices)
        {
            _trackingServices = trackingServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTrackings()
        {
            try
            {
                var trackings = await _trackingServices.GetAllTrackingsAsync();
                return Ok(trackings);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTrackingById(int id)
        {
            try
            {
                var tracking = await _trackingServices.GetTrackingByIdAsync(id);
                return Ok(tracking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateTracking([FromBody] Tracking_Request tracking)
        {
            try
            {
                var result = await _trackingServices.CreateTrackingAsync(tracking);
                return CreatedAtAction(nameof(GetTrackingById), new { id = tracking.Id }, result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTracking(int id, [FromBody] Tracking_Request tracking)
        {
            try
            {
                var updatedTracking = await _trackingServices.UpdateTracking(id, tracking);
                return Ok(updatedTracking);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTracking(int id)
        {
            try
            {
                var result = await _trackingServices.DeleteTracking(id);
                if (result)
                {
                    return NoContent();
                }
                return NotFound(new { message = "Tracking not found" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
