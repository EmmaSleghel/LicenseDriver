﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Student
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
    }
}
