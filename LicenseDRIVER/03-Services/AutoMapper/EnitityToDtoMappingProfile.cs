using AutoMapper;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.AutoMapper
{
    public class EnitityToDtoMappingProfile : Profile
    {
        public EnitityToDtoMappingProfile()
        {
            CreateMap<Data.Entities.Student, StudentDto>();
            CreateMap<StudentDto, Data.Entities.Student>();
            CreateMap<Data.Entities.Teacher, TeacherDto>();
            CreateMap<TeacherDto, Data.Entities.Teacher > ();
            CreateMap<Data.Entities.Notification, NotificationDto>();
            CreateMap<NotificationDto, Data.Entities.Notification>();


        }
    }
}
