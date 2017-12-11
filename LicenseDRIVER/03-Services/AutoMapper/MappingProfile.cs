using AutoMapper;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Entities.Student, StudentDto>();
        }
    }
}
