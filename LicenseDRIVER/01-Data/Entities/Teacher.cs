﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Teacher : User
    {
        public Guid TeacherId { get; set; }
        public string Class { get; set; }

    }
}
