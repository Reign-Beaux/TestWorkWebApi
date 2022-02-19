using AutoMapper;
using BackendTestWork.DTOs;
using BackendTestWork.Entities;

namespace BackendTestWork.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<CreatePersonDTO, Person>();
        }
    }
}
