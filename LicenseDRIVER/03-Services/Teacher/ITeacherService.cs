using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Teacher
{
    public interface ITeacherService
    {
        TeacherDto GetTeacherById(Guid id);
        TeacherDto GetTeacherByUsername(string username);
        void CreateTeacher(TeacherDto teacher);
    }
}
