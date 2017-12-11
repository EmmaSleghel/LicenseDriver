using Business.Repository;
using System;
using AutoMapper;
using Services.Dtos;

namespace Services.Student
{
    public class StudentService:IStudentService
    {
        public IRepository<Data.Entities.Student> studentRepository { get; set; }
        private  IMapper mapper { get; set; }
        public StudentService(IRepository<Data.Entities.Student> studentRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
        }
        public StudentDto GetStudentById(Guid id)
        {
            return mapper.Map<StudentDto>(studentRepository.GetByKey(id));

        }
    }
}
