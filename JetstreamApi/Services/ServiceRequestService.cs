using JetstreamApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JetstreamApi.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly ServiceRequestDbContext _context;

        public ServiceRequestService(ServiceRequestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync()
        {
            return await _context.ServiceRequest.ToListAsync();
        }

        public async Task<ServiceRequest> GetServiceRequestByIdAsync(int id)
        {
            return await _context.ServiceRequest.FindAsync(id);
        }

        public async Task<ServiceRequest> CreateServiceRequestAsync(ServiceRequest serviceRequest)
        {
            _context.ServiceRequest.Add(serviceRequest);
            await _context.SaveChangesAsync();
            return serviceRequest;
        }

        public async Task UpdateServiceRequestAsync(ServiceRequest serviceRequest)
        {
            _context.Entry(serviceRequest).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteServiceRequestAsync(int id)
        {
            var serviceRequest = await _context.ServiceRequest.FindAsync(id);
            if (serviceRequest != null)
            {
                _context.ServiceRequest.Remove(serviceRequest);
                await _context.SaveChangesAsync();
            }
        }
    }
}
