using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dtos
{
   public class TeacherDto:UserDto
    {
        public Guid TeacherId { get; set; }
        public string Class { get; set; }

    }
}
