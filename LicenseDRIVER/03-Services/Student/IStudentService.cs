using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Student
{
    public interface IStudentService
    {
        StudentDto GetStudentById(Guid id);
       void CreateStudent(Data.Entities.Student student);
    }
}
