using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Student
{
    public interface IStudentService
    {
        StudentDto GetStudentById(Guid id);
        StudentDto GetStudentByUsername(string username);

        void CreateStudent(StudentDto student);
    }
}
