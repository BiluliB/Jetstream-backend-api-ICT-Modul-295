using JetstreamApi.Data;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;
using JetstreamApi.Interfaces;
using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var serviceRequests = await _context.ServiceRequests.ToListAsync();

            return serviceRequests.Select(request => new ServiceRequestDTO
            {
                Id = request.Id,
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                Phone = request.Phone,
                Priority = request.Priority,
                CreateDate = request.CreateDate,
                PickupDate = request.PickupDate,
                ServiceId = request.ServiceId,
                Price = request.Price,
                StatusId = request.StatusId,
                Comment = request.Comment
            }).ToList();
        }

        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(id);

            if (serviceRequest == null) return null;

            return new ServiceRequestDTO
            {
                Id = serviceRequest.Id,
                Firstname = serviceRequest.Firstname,
                Lastname = serviceRequest.Lastname,
                Email = serviceRequest.Email,
                Phone = serviceRequest.Phone,
                Priority = serviceRequest.Priority,
                CreateDate = serviceRequest.CreateDate,
                PickupDate = serviceRequest.PickupDate,
                ServiceId = serviceRequest.ServiceId,
                Price = serviceRequest.Price,
                StatusId = serviceRequest.StatusId,
                Comment = serviceRequest.Comment
            };
        }

        public async Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync(string sort)
        {
            IQueryable<ServiceRequest> query = _context.ServiceRequests;

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
                query = query.OrderByDescending(sr => sr.Priority)
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
                Priority = sr.Priority,
                CreateDate = sr.CreateDate,
                PickupDate = sr.PickupDate,
                ServiceId = sr.ServiceId,
                Price = sr.Price,
                StatusId = sr.StatusId,
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
                Priority = dto.Priority,
                CreateDate = dto.CreateDate,
                PickupDate = dto.PickupDate,
                ServiceId = dto.ServiceId,
                Price = dto.Price,
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
                Priority = serviceRequest.Priority,
                CreateDate = serviceRequest.CreateDate,
                PickupDate = serviceRequest.PickupDate,
                ServiceId = serviceRequest.ServiceId,
                Price = serviceRequest.Price,
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
                serviceRequest.Priority = dto.Priority;
                serviceRequest.CreateDate = dto.CreateDate;
                serviceRequest.PickupDate = dto.PickupDate;
                serviceRequest.ServiceId = dto.ServiceId;
                serviceRequest.Price = dto.Price;
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
                _context.ServiceRequests.Remove(serviceRequest);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("ServiceRequest not found.");
            }
        }
    }
}
