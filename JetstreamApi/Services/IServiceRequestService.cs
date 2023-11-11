using JetstreamApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JetstreamApi.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<ServiceRequest> GetServiceRequestByIdAsync(int id);
        Task<ServiceRequest> CreateServiceRequestAsync(ServiceRequest serviceRequest);
        Task UpdateServiceRequestAsync(ServiceRequest serviceRequest);
        Task DeleteServiceRequestAsync(int id);
    }
}
