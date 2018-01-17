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
        List<StudentDto>GetStudentsByTeacherId(Guid id);
        void CreateStudent(StudentDto student);
    }
}
