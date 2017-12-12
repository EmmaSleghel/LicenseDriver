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
            CreateMap<Data.Entities.Student, StudentDto>()
                .ForMember(x => x.Password, opt => opt.MapFrom(z => z.Password))
                .ForMember(x => x.Username, opt => opt.MapFrom(z => z.Username))
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(z => z.TeacherId)); ;
            CreateMap<StudentDto, Data.Entities.Student>()
                .ForMember(x => x.Password, opt => opt.MapFrom(z => z.Password))
                .ForMember(x => x.Username, opt => opt.MapFrom(z => z.Username))
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(z => z.TeacherId)); ;
            CreateMap<Data.Entities.Teacher, TeacherDto>()
                .ForMember(x=>x.Password,opt=>opt.MapFrom(z=>z.Password))
                .ForMember(x=>x.Username,opt=>opt.MapFrom(z=>z.Username))
                .ForMember(x=>x.TeacherId, opt=>opt.MapFrom(z=>z.TeacherId));
            CreateMap<TeacherDto, Data.Entities.Teacher>()
                .ForMember(x => x.Password, opt => opt.MapFrom(z => z.Password))
                .ForMember(x => x.Username, opt => opt.MapFrom(z => z.Username))
                .ForMember(x => x.TeacherId, opt => opt.MapFrom(z => z.TeacherId)); ;
            


        }
    }
}
