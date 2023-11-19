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
            // Fetch prices for Service and Priority
            var servicePrice = await _context.Services
                .Where(s => s.Id == dto.ServiceId)
                .Select(s => s.Price)
                .FirstOrDefaultAsync();

            var priorityPrice = await _context.Priorities
                .Where(p => p.Id == dto.PriorityId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            // Calculate total price
            var totalPrice = servicePrice + priorityPrice;
            var serviceRequest = new ServiceRequest
            {
                
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Email = dto.Email,
                Phone = dto.Phone,
                PriorityId = dto.PriorityId,
                CreateDate = dto.CreateDate,
                PickupDate = dto.PickupDate,
                ServiceId = dto.ServiceId,
                StatusId = 1,
                Comment = dto.Comment
            };

            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            await _context.Entry(serviceRequest).Reference(s => s.Priority).LoadAsync();
            await _context.Entry(serviceRequest).Reference(s => s.Service).LoadAsync();
            await _context.Entry(serviceRequest).Reference(s => s.Status).LoadAsync();

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
                Price = totalPrice,
                StatusId = serviceRequest.StatusId,
                Status = serviceRequest.Status,
                Comment = serviceRequest.Comment
            };
        }

        public async Task<ServiceRequestDTO?> UpdateServiceRequestAsync(int Id, ServiceRequestUpdateDTO dto)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(Id);
            if (serviceRequest == null) return null;
                            
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
                    Price = serviceRequest.Priority.Price + serviceRequest.Service.Price,
                    StatusId = serviceRequest.StatusId,
                    Status = serviceRequest.Status,
                    Comment = serviceRequest.Comment
                };
            
            
            
                
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
