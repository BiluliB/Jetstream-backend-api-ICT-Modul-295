using Microsoft.AspNetCore.Mvc;
using JetstreamApi.DTO;
using JetstreamApi.Services;
using System.Threading.Tasks;
using JetstreamApi.DTOs;

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

        // GET: api/ServiceRequests
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllServiceRequests()
        {
            var serviceRequestDTOs = await _serviceRequestService.GetAllServiceRequestsAsync();
            return Ok(serviceRequestDTOs);
        }

        // GET: api/ServiceRequests/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        // POST: api/ServiceRequests
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateServiceRequest([FromBody] ServiceRequestCreateDTO serviceRequestCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serviceRequestDTO = await _serviceRequestService.CreateServiceRequestAsync(serviceRequestCreateDTO);
            return CreatedAtAction(nameof(GetServiceRequestById), new { id = serviceRequestDTO.Id }, serviceRequestDTO);
        }

        // PUT: api/ServiceRequests/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateServiceRequest(int id, [FromBody] ServiceRequestUpdateDTO serviceRequestUpdateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceRequestUpdateDTO.Id)
            {
                return BadRequest("Die ID in der URL stimmt nicht mit der ID im Body überein.");
            }

            var existingServiceRequest = await _serviceRequestService.GetServiceRequestByIdAsync(id);
            if (existingServiceRequest == null)
            {
                return NotFound();
            }

            // Aktualisieren Sie den ServiceRequest
            await _serviceRequestService.UpdateServiceRequestAsync(serviceRequestUpdateDTO);
            return Ok(serviceRequestUpdateDTO);
        }


        // DELETE: api/ServiceRequests/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
    }
}
