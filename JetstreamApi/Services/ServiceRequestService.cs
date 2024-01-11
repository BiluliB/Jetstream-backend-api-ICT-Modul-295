using JetstreamApi.Data;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;
using JetstreamApi.Interfaces;
using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace JetstreamApi.Services
{
    /// <summary>
    /// Service for managing service requests.
    /// </summary>
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceRequestService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
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

            return _mapper.Map<IEnumerable<ServiceRequestDTO>>(serviceRequests);
        }


        public async Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id)
        {
            var serviceRequest = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.Id == id);

            return _mapper.Map<ServiceRequestDTO>(serviceRequest);
        }

        public async Task<ServiceRequestDTO> CreateServiceRequestAsync(ServiceRequestCreateDTO createDto)
        {
            var serviceRequest = _mapper.Map<ServiceRequest>(createDto);

            if (serviceRequest.StatusId == 0)
            {
                serviceRequest.StatusId = 1;
            }

            // Preise für Service und Priority abrufen
            var servicePrice = await _context.Services
                .Where(s => s.Id == serviceRequest.ServiceId)
                .Select(s => s.Price)
                .FirstOrDefaultAsync();

            var priorityPrice = await _context.Priorities
                .Where(p => p.Id == serviceRequest.PriorityId)
                .Select(p => p.Price)
                .FirstOrDefaultAsync();

            // Gesamtbetrag berechnen
            serviceRequest.TotalPrice_CHF = servicePrice + priorityPrice;

            _context.ServiceRequests.Add(serviceRequest);
            await _context.SaveChangesAsync();

            // Lade die referenzierten Entitäten, falls benötigt
            await _context.Entry(serviceRequest).Reference(s => s.Priority).LoadAsync();
            await _context.Entry(serviceRequest).Reference(s => s.Service).LoadAsync();
            await _context.Entry(serviceRequest).Reference(s => s.Status).LoadAsync();

            return _mapper.Map<ServiceRequestDTO>(serviceRequest);
        }


        public async Task<ServiceRequestDTO> UpdateServiceRequestAsync(int id, ServiceRequestUpdateDTO updateDto)
        {
            var serviceRequest = await _context.ServiceRequests
                .FirstOrDefaultAsync(sr => sr.Id == id);

            if (serviceRequest == null)
            {
                // Handle the case where the service request doesn't exist
                return null;
            }

            // Überprüfe, ob die PriorityId gültig ist
            var validPriority = await _context.Priorities.AnyAsync(p => p.Id == updateDto.PriorityId);
            if (!validPriority)
            {
                throw new ArgumentException($"Die PriorityId '{updateDto.PriorityId}' existiert nicht in der Datenbank.");
            }

            _mapper.Map(updateDto, serviceRequest);

            _context.ServiceRequests.Update(serviceRequest);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceRequestDTO>(serviceRequest);
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

        public async Task<List<ServiceRequestDTO>> GetAllServiceRequestsByPriorty(int priority)
        {
            // Check whether the priority is valid
            var validPriorities = new int[] { 1, 2, 3 };
            if (!validPriorities.Contains(priority))
            {
                throw new KeyNotFoundException($"Die Priorität '{priority}' existiert nicht. Verwende Sie die ID 1, 2 oder 3.");
            }

            var serviceRequests = await _context.ServiceRequests
                .Where(s => s.PriorityId == priority)
                .ToListAsync();

            return _mapper.Map<List<ServiceRequestDTO>>(serviceRequests);
        }

        public Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AssignServiceRequestToUser(int serviceRequestId, int userId)
        {
            var serviceRequest = await _context.ServiceRequests.FindAsync(serviceRequestId);
            if (serviceRequest == null)
            {
                throw new KeyNotFoundException($"Service Request mit der ID {serviceRequestId} wurde nicht gefunden.");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException($"User mit der ID {userId} wurde nicht gefunden.");
            }

            serviceRequest.UserId = userId;
            await _context.SaveChangesAsync();
        }
    }
}
