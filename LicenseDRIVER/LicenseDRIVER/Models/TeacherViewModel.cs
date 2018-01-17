using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseDRIVER.Models
{
    public class TeacherViewModel:UserViewModel
    {
        public Guid TeacherId { get; set; }
        public string Class { get; set; }
    }
}
