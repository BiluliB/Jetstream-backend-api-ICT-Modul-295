using JetstreamApi.DTO;
using JetstreamApi.DTOs;

namespace JetstreamApi.Interfaces
{
    public interface IServiceRequestService
    {
        Task<ServiceRequestDTO> CreateServiceRequestAsync(ServiceRequestCreateDTO dto);
        Task DeleteServiceRequestAsync(int id);
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync();
        Task<IEnumerable<ServiceRequestDTO>> GetAllServiceRequestsAsync(string sort);
        Task<List<ServiceRequestDTO>> GetAllServiceRequestsByPriorty(int protity);
        Task<ServiceRequestDTO> GetServiceRequestByIdAsync(int id);
        Task<ServiceRequestDTO> UpdateServiceRequestAsync(int id, ServiceRequestUpdateDTO dto);
    }
}