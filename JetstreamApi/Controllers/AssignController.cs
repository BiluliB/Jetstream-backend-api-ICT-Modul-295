using JetstreamApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    public class AssignController : Controller
    {
        private readonly IAssignService _assignService;

        public AssignController(IAssignService assignService)
        {
            _assignService = assignService;
        }

        [HttpPost("{Id}/assign/{userId}")]
        [Authorize(Roles = "ADMIN, USER")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignServiceRequestToUser(int Id, int userId)
        {
            try
            {
                string currentUserName = User.Identity?.Name;
                await _assignService.AssignServiceRequestToUser(Id, userId, currentUserName);
                return Ok($"Auftrag {Id} wurde erfolgreich dem User {userId} zugewiesen.");
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{Id}/assign/{userId}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> ReassignServiceRequestToUser(int Id, int userId)
        {
            try
            {
                await _assignService.AssignServiceRequestToUser(Id, userId);
                return Ok($"ServiceRequest {Id} wurde erfolgreich User {userId} zugewiesen.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
