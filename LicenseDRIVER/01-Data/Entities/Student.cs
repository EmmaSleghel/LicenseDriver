using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Student :User
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
