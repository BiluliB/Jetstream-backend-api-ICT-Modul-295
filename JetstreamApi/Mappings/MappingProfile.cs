using AutoMapper;
using JetstreamApi.DTO;
using JetstreamApi.DTOs;
using JetstreamApi.Models;

namespace JetstreamApi.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Automate the mapping of DTOs to models and vice versa
            CreateMap<ServiceRequest, ServiceRequestCreateDTO>();
            CreateMap<ServiceRequestCreateDTO, ServiceRequest>();

            CreateMap<ServiceRequest, ServiceRequestDTO>();
            CreateMap<ServiceRequestDTO, ServiceRequest>();

            CreateMap<ServiceRequest, ServiceRequestUpdateDTO>();
            CreateMap<ServiceRequestUpdateDTO, ServiceRequest>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserCreateDTO>();
            CreateMap<UserCreateDTO, User>();

            CreateMap<User, UserLoginDTO>();
            CreateMap<UserLoginDTO, User>();
        }
    }
}
