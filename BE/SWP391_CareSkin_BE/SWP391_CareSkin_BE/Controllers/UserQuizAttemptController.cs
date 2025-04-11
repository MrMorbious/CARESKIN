using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP391_CareSkin_BE.DTOS.Requests.UserQuizAttempt;
using SWP391_CareSkin_BE.DTOS.Responses.UserQuizAttempt;
using SWP391_CareSkin_BE.Services.Interfaces;

namespace SWP391_CareSkin_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserQuizAttemptController : ControllerBase
    {
        private readonly IUserQuizAttemptService _userQuizAttemptService;

        public UserQuizAttemptController(IUserQuizAttemptService userQuizAttemptService)
        {
            _userQuizAttemptService = userQuizAttemptService;
        }

        [HttpPost]
        public async Task<ActionResult<UserQuizAttemptDTO>> CreateUserQuizAttempt([FromBody] CreateUserQuizAttemptDTO createUserQuizAttemptDTO)
        {
            try
            {
                var attempt = await _userQuizAttemptService.CreateUserQuizAttemptAsync(createUserQuizAttemptDTO);
                return Ok(attempt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{userQuizAttemptId}")]
        public async Task<ActionResult<UserQuizAttemptDTO>> GetUserQuizAttemptById(int userQuizAttemptId, [FromQuery] bool includeHistories = false)
        {
            try
            {
                var attempt = await _userQuizAttemptService.GetUserQuizAttemptByIdAsync(userQuizAttemptId, includeHistories);
                
                if (attempt == null)
                {
                    return NotFound($"User quiz attempt with ID {userQuizAttemptId} not found");
                }
                
                return Ok(attempt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("customer/{customerId}")]
        public async Task<ActionResult<List<UserQuizAttemptDTO>>> GetUserQuizAttemptsByCustomerId(int customerId, [FromQuery] bool includeHistories = false)
        {
            try
            {
                var attempts = await _userQuizAttemptService.GetUserQuizAttemptsByCustomerIdAsync(customerId, includeHistories);
                return Ok(attempts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("quiz/{quizId}/customer/{customerId}")]
        public async Task<ActionResult<List<UserQuizAttemptDTO>>> GetUserQuizAttemptsByQuizAndCustomer(int quizId, int customerId, [FromQuery] bool includeHistories = false)
        {
            try
            {
                var attempts = await _userQuizAttemptService.GetUserQuizAttemptsByQuizAndCustomerAsync(quizId, customerId, includeHistories);
                return Ok(attempts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{userQuizAttemptId}/complete")]
        public async Task<ActionResult<UserQuizAttemptDTO>> CompleteUserQuizAttempt(int userQuizAttemptId)
        {
            try
            {
                var attempt = await _userQuizAttemptService.CompleteUserQuizAttemptAsync(userQuizAttemptId);
                
                if (attempt == null)
                {
                    return NotFound($"User quiz attempt with ID {userQuizAttemptId} not found");
                }
                
                return Ok(attempt);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
