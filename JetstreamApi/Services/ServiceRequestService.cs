using JetstreamApi.Data;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;
using JetstreamApi.Interfaces;
using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JetstreamApi.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;

        public ServiceRequestService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync()
        {
            var serviceRequests = await _context.ServiceRequests.Where(s => s.StatusId != 4).ToListAsync();

            return serviceRequests.Select(request => new ServiceRequestDTO
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                Phone = request.Phone,
                PriorityId = request.PriorityId,
                Priority = request.Priority,
                CreateDate = request.CreateDate,
                PickupDate = request.PickupDate,
                ServiceId = request.ServiceId,
                Service = request.Service,
                StatusId = request.StatusId,
                Status = request.Status,
                Comment = request.Comment
            }).ToList();
        }

        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id)
        {
            ServiceRequest? serviceRequest = null;

            try
            {
                serviceRequest = await _context.ServiceRequests.FirstAsync(s => s.StatusId != 4 && s.Id == id);
            }catch (Exception ex)
            {
                return null;
            }
            

            return new ServiceRequestDTO
            {
                Id = serviceRequest.Id,
                Firstname = serviceRequest.Firstname,
                Lastname = serviceRequest.Lastname,
                Email = serviceRequest.Email,
                Phone = serviceRequest.Phone,
                PriorityId = serviceRequest.PriorityId,
                Priority = serviceRequest.Priority,
                CreateDate = serviceRequest.CreateDate,
                PickupDate = serviceRequest.PickupDate,
                ServiceId = serviceRequest.ServiceId,
                Service = serviceRequest.Service,
                StatusId = serviceRequest.StatusId,
                Status = serviceRequest.Status,
                Comment = serviceRequest.Comment
            };
        }

        public async Task<List<ServiceRequestDTO>> GetAllServiceRequestsByPriorty(int protity)
        {
            var priorities = await _context.ServiceRequests.Where(s => s.PriorityId == protity).ToListAsync();

            return priorities.Select(request => new ServiceRequestDTO
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                Phone = request.Phone,
                PriorityId = request.PriorityId,
                Priority = request.Priority,
                CreateDate = request.CreateDate,
                PickupDate = request.PickupDate,
                ServiceId = request.ServiceId,
                Service = request.Service,
                StatusId = request.StatusId,
                Status = request.Status,
                Comment = request.Comment
            }).ToList();
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync(string sort)
        {
            IQueryable<ServiceRequest> query = _context.ServiceRequests.Where(s => s.StatusId != 4);

            // Standard-Sortierung basierend auf Status und PickupDate
            if (sort == "default")
            {
                query = query.OrderBy(sr => sr.StatusId == 4) // storniert
                             .ThenBy(sr => sr.StatusId == 3) // abgeschlossen
                             .ThenBy(sr => sr.StatusId == 2) // in Arbeit
                             .ThenBy(sr => sr.StatusId == 1) // offen
                             .ThenBy(sr => sr.PickupDate);
            }

            // Sortierung nach Priorität und PickupDate
            else if (sort == "priority")
            {
                query = query.OrderByDescending(sr => sr.PriorityId)
                             .ThenBy(sr => sr.PickupDate);
            }

            var serviceRequests = await query.ToListAsync();
            var serviceRequestDTOs = serviceRequests.Select(sr => new ServiceRequestDTO
            {
                Id = sr.Id,
                Firstname = sr.Firstname,
                Lastname = sr.Lastname,
                Email = sr.Email,
                Phone = sr.Phone,
                PriorityId = sr.PriorityId,
                Priority = sr.Priority,
                CreateDate = sr.CreateDate,
                PickupDate = sr.PickupDate,
                ServiceId = sr.ServiceId,
                Service = sr.Service,
                StatusId = sr.StatusId,
                Status = sr.Status,
                Comment = sr.Comment,
            }).ToList();

            return serviceRequestDTOs;
        }

        public async Task<ServiceRequestDTO> CreateServiceRequestAsync(ServiceRequestCreateDTO dto)
        {
            var serviceRequest = new ServiceRequest
            {
                Id = dto.Id,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Phone = dto.Phone,
                PriorityId = dto.PriorityId,
                CreateDate = dto.CreateDate,
                PickupDate = dto.PickupDate,
                ServiceId = dto.ServiceId,
                StatusId = dto.StatusId,
                Comment = dto.Comment
            };

            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            return new ServiceRequestDTO
            {
                Id = serviceRequest.Id,
                Firstname = serviceRequest.Firstname,
                Lastname = serviceRequest.Lastname,
                Email = serviceRequest.Email,
                Phone = serviceRequest.Phone,
                PriorityId = serviceRequest.PriorityId,
                CreateDate = serviceRequest.CreateDate,
                PickupDate = serviceRequest.PickupDate,
                ServiceId = serviceRequest.ServiceId,
                StatusId = serviceRequest.StatusId,
                Comment = serviceRequest.Comment
            };
        }

        public async Task UpdateServiceRequestAsync(ServiceRequestUpdateDTO dto)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(dto.Id);
            if (serviceRequest != null)
            {

                serviceRequest.Firstname = dto.Firstname;
                serviceRequest.Lastname = dto.Lastname;
                serviceRequest.Email = dto.Email;
                serviceRequest.Phone = dto.Phone;
                serviceRequest.PriorityId = dto.PriorityId;
                serviceRequest.CreateDate = dto.CreateDate;
                serviceRequest.PickupDate = dto.PickupDate;
                serviceRequest.ServiceId = dto.ServiceId;
                serviceRequest.StatusId = dto.StatusId;
                serviceRequest.Comment = dto.Comment;

                _context.Entry(serviceRequest).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("ServiceRequest not found.");
            }
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);
            if (serviceRequest != null)
            {
                serviceRequest.StatusId = 4;
                //_context.ServiceRequests.Remove(serviceRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("ServiceRequest not found.");
            }
        }
    }
}
