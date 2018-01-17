using AutoMapper;
using LicenseDRIVER.Models;
using Services.Dtos;


namespace LicenseDRIVER.AutoMapper
{
    public class DtoToViewModelMappingProfile : Profile
    {
        public DtoToViewModelMappingProfile()
        {
            CreateMap<StudentDto, StudentViewModel>();
            CreateMap<StudentViewModel, StudentDto>();
            CreateMap<TeacherDto, TeacherViewModel>();
            CreateMap<TeacherViewModel, TeacherDto>();
            CreateMap<TeacherViewModel, TeacherDto>();
            CreateMap<NotificationViewModel, NotificationDto>();
            CreateMap<NotificationDto, NotificationViewModel>();



        }
    }
}
