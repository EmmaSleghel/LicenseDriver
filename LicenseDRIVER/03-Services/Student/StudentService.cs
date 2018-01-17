using Business.Repository;
using System;
using AutoMapper;
using Services.Dtos;
using Business.Infrastructure;
using System.Linq;
using System.Collections.Generic;

namespace Services.Student
{
    public class StudentService:IStudentService
    {
        public IRepository<Data.Entities.Student> studentRepository { get; set; }
        private  IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork { get; set; }
        public StudentService(IRepository<Data.Entities.Student> studentRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.studentRepository = studentRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public StudentDto GetStudentById(Guid id)
        {
            var student = studentRepository.GetByKey(id);
            if (student == null) return null;
            return mapper.Map<StudentDto>(student);

        }
        public void  CreateStudent(StudentDto student)
        {
            var studentEntity = mapper.Map<Data.Entities.Student>(student);
            studentRepository.Add(studentEntity);
            unitOfWork.Commit();
        }

        public StudentDto GetStudentByUsername(string username)
        {
            var studentEntity = studentRepository.Query().FirstOrDefault(x => x.Username == username);
            return mapper.Map<StudentDto>(studentEntity);
        }
        public List<StudentDto> GetStudentsByTeacherId(Guid id)
        {
            var studentlist = studentRepository.Query().ToList();
            return Mapper.Map<List<StudentDto>>(studentlist);
        }
    }
}
