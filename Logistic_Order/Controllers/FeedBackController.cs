using Logistic_Order.ILogics.IServices;
using Logistic_Order.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistic_Order.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedbackServices _feedbackServices;
        public FeedBackController(IFeedbackServices feedbackServices)
        {
            _feedbackServices = feedbackServices;
        }
        [HttpPost("AddFeedback")]
        public async Task<IActionResult> AddFeedback([FromBody] FeedbackRequest feedbackRequest)
        {
            try
            {
                if (feedbackRequest == null)
                {
                    return BadRequest("Feedback request cannot be null");
                }
                var result = await _feedbackServices.AddFeedback(feedbackRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("UpdateFeedback/{id}")]
        public async Task<IActionResult> UpdateFeedback(int id, [FromBody] FeedbackRequest feedbackRequest)
        {
            try
            {
                if (feedbackRequest == null)
                {
                    return BadRequest("Feedback request cannot be null");
                }
                var result = await _feedbackServices.UpdateFeedback(id, feedbackRequest);
                if (result == null)
                {
                    return NotFound($"Feedback with ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteFeedback/{id}")]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            try
            {
                var result = await _feedbackServices.DeleteFeedback(id);
                if (result == null)
                {
                    return NotFound($"Feedback with ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetFeedbackById/{id}")]
        public async Task<IActionResult> GetFeedbackById(int id)
        {
            try
            {
                var result = await _feedbackServices.GetFeedbackById(id);
                if (result == null)
                {
                    return NotFound($"Feedback with ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetAllFeedback")]
        public async Task<IActionResult> GetAllFeedback()
        {
            try
            {
                var result = await _feedbackServices.GetAllFeedback();
                if (result == null || !result.Any())
                {
                    return NotFound("No feedback found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
        }
    }
}
