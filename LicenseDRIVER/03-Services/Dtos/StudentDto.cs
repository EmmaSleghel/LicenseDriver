using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dtos
{
    public class StudentDto:UserDto
    {
        public Guid StudentId { get; set; }
        public string Class { get; set; }
        public Guid TeacherId { get; set; }
    }
}
