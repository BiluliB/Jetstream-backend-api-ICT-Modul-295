using JetstreamApi.DTO;
using JetstreamApi.DTOs;
using JetstreamApi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JetstreamApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
  
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;

        public ServiceRequestsController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }
        /// <summary>
        /// Retrieves all service requests matching a specific priority level.
        /// </summary>
        /// <param name="sort">The priority level to filter service requests.</param>
        /// <returns>A list of ServiceRequestDTO objects.</returns>
        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (List<ServiceRequestDTO>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllServiceRequests([FromQuery] string sort = "default")
        {
            var serviceRequestDTOs = await _serviceRequestService.GetAllServiceRequestsAsync(sort);
            return Ok(serviceRequestDTOs);
        }

        /// <summary>
        /// Retrieves a specific service request by its ID
        /// </summary>
        /// <param name="id">The ID of the service request</param>
        /// <returns>A ServiceRequestDTO object if found; otherwise, a 404 Not Found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof (ServiceRequestDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetServiceRequestById(int id)
        {
            var serviceRequestDTO = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (serviceRequestDTO == null)
            {
                return NotFound();
            }
            return Ok(serviceRequestDTO);
        }
        /// <summary>
        /// Retrieves all service requests matching a specific priority level
        /// </summary>
        /// <param name="priority">The priority level to filter service requests</param>
        /// <returns>A list of ServiceRequestDTO objects</returns>
        [HttpGet("priorities/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceRequestDTO))]
        public async Task<IActionResult> GetAllServiceRequestsByPriorty(int id)
        {
            var serviceRequestDTOs = await _serviceRequestService.GetAllServiceRequestsByPriorty(id);
            return Ok(serviceRequestDTOs);
        }

        /// <summary>
        /// Creates a new service request from the provided DTO
        /// </summary>
        /// <param name="serviceRequestCreateDTO">The DTO containing service request data</param>
        /// <returns>A newly created ServiceRequestDTO object</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceRequestCreateDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> CreateServiceRequest([FromBody] ServiceRequestCreateDTO serviceRequestCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceRequestDTO = await _serviceRequestService.CreateServiceRequestAsync(serviceRequestCreateDTO);
            return CreatedAtAction(nameof(GetServiceRequestById), new { id = serviceRequestDTO.Id }, serviceRequestDTO);
        }

        /// <summary>
        /// Updates an existing service request identified by its ID with the provided DTO data.
        /// </summary>
        /// <param name="id">The ID of the service request to update.</param>
        /// <param name="serviceRequestUpdateDTO">The DTO containing updated data for the service request.</param>
        /// <returns>The updated ServiceRequestDTO object if found; otherwise, a 404 Not Found.</returns>       
        [HttpPut("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceRequestUpdateDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "ADMIN,USER")]
        public async Task<IActionResult> UpdateServiceRequest(int id, [FromBody] ServiceRequestUpdateDTO serviceRequestUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
  

            var updatedServiceRequest = await _serviceRequestService.UpdateServiceRequestAsync(id, serviceRequestUpdateDTO);
            if (updatedServiceRequest == null)
            {
                return NotFound();
            }
            return Ok(updatedServiceRequest);
        }

        /// <summary>
        /// Deletes a service request identified by its ID.
        /// </summary>
        /// <param name="id">The ID of the service request to delete.</param>
        /// <returns>A 200 OK if successful; otherwise, a 404 Not Found.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN,USER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceRequestDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteServiceRequest(int id)   
        {
            var serviceRequestDTO = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (serviceRequestDTO == null)
            {
                return NotFound();
            }

            await _serviceRequestService.DeleteServiceRequestAsync(id);
            return Ok();
        }

        [HttpPost("{Id}/assign/{userId}")]
        [Authorize(Roles = "ADMIN, USER")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AssignServiceRequestToUser(int Id, int userId)
        {
            try
            {
                await _serviceRequestService.AssignServiceRequestToUser(Id, userId);
                return Ok($"Auftrag {Id} wurde erfolgreich dem User {userId} zugewiesen.");
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
