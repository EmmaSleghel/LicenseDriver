using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
