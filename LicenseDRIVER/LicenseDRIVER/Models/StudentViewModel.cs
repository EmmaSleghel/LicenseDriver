using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseDRIVER.Models
{
    public class StudentViewModel:UserViewModel
    {
        public Guid StudentId { get; set; }
        public string Class { get; set; }
        public Guid TeacherId { get; set; }
    }
}
