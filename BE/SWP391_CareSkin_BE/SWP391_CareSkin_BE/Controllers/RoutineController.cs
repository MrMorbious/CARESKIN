using Microsoft.AspNetCore.Mvc;
using SWP391_CareSkin_BE.DTOS.Requests.Routine;
using SWP391_CareSkin_BE.DTOS.Responses.Routine;
using SWP391_CareSkin_BE.Exceptions;
using SWP391_CareSkin_BE.Services.Interfaces;

namespace SWP391_CareSkin_BE.Controllers
{
    [Route("api/routines")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;
        private readonly IRoutineStepService _routineStepService;

        public RoutineController(
            IRoutineService routineService,
            IRoutineStepService routineStepService)
        {
            _routineService = routineService;
            _routineStepService = routineStepService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RoutineDTO>>> GetAllRoutines()
        {
            try
            {
                var routines = await _routineService.GetAllRoutinesAsync();
                return Ok(routines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("active")]
        public async Task<ActionResult<List<RoutineDTO>>> GetActiveRoutines()
        {
            try
            {
                var routines = await _routineService.GetActiveRoutinesAsync();
                return Ok(routines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("inactive")]
        public async Task<ActionResult<List<RoutineDTO>>> GetInactiveRoutines()
        {
            try
            {
                var routines = await _routineService.GetInactiveRoutinesAsync();
                return Ok(routines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoutineDTO>> GetRoutineById(int id)
        {
            try
            {
                var routine = await _routineService.GetRoutineByIdAsync(id);
                return Ok(routine);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("skinType/{skinTypeId}")]
        public async Task<ActionResult<List<RoutineDTO>>> GetRoutineBySkinTypeId(int skinTypeId)
        {
            try
            {
                var routines = await _routineService.GetRoutinesBySkinTypeIdAsync(skinTypeId);
                return Ok(routines);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<RoutineDTO>> CreateRoutine([FromBody] RoutineCreateRequestDTO request)
        {
            try
            {
                var routine = await _routineService.CreateRoutineAsync(request);
                return CreatedAtAction(nameof(GetRoutineById), new { id = routine.RoutineId }, routine);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoutineDTO>> UpdateRoutine(int id, [FromBody] RoutineUpdateRequestDTO request)
        {
            try
            {
                var routine = await _routineService.UpdateRoutineAsync(id, request);
                return Ok(routine);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRoutine(int id)
        {
            try
            {
                await _routineService.DeleteRoutineAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
