using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Teacher :User
    {
        public Guid TeacherId { get; set; }
        public String Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
