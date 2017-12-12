using AutoMapper;
using Data.Entities;
using Services.Dtos;


namespace Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
