using AutoMapper;
using Business.Infrastructure;
using Business.Repository;
using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Teacher
{
    public class TeacherService:ITeacherService
    {
        public IRepository<Data.Entities.Teacher> teacherRepository { get; set; }
        private IMapper mapper { get; set; }
        private IUnitOfWork unitOfWork { get; set; }

        public TeacherService(IRepository<Data.Entities.Teacher> teacherRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public TeacherDto GetTeacherById(Guid id)
        {
            var teacher = teacherRepository.GetByKey(id);
            if (teacher == null) return null;
            return mapper.Map<TeacherDto>(teacher);
        }
        public void CreateTeacher(TeacherDto teacher)
        {
            var teacherEntity = mapper.Map<Data.Entities.Teacher>(teacher);
            teacherRepository.Add(teacherEntity);
            unitOfWork.Commit();
        }

        public TeacherDto GetTeacherByUsername(string username)
        {
            var teacherEntity = teacherRepository.Query().FirstOrDefault(x => x.Username == username);
            return mapper.Map<TeacherDto>(teacherEntity);
        }
    }
}
