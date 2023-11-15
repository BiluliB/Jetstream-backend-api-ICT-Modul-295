using System.Collections.Generic;
using System.Threading.Tasks;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;

namespace JetstreamApi.Services
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id);
        Task<ServiceRequestDTO> CreateServiceRequestAsync(ServiceRequestCreateDTO dto);
        Task UpdateServiceRequestAsync(ServiceRequestUpdateDTO dto);
        Task DeleteServiceRequestAsync(int id);
    }
}
