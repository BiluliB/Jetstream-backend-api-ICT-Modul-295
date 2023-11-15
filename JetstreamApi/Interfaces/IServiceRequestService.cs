using System.Collections.Generic;
using System.Threading.Tasks;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;

namespace JetstreamApi.Interfaces
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync();
        Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id);
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync(string sort);
        Task<ServiceRequestDTO> CreateServiceRequestAsync(ServiceRequestCreateDTO dto);
        Task UpdateServiceRequestAsync(ServiceRequestUpdateDTO dto);
        Task DeleteServiceRequestAsync(int id);
    }
}
