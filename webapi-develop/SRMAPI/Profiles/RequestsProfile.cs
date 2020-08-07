using AutoMapper;
using SRMAPI.DTOs;
using SRMAPI.Models;

namespace SRMAPI.Profiles{
    public class RequestsProfile : Profile{
        public RequestsProfile()
        {
            CreateMap<Request, RequestReadDto>(); 
        }
    }
}