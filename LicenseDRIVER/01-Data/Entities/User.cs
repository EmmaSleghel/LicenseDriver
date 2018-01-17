using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
   public  class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set;}
        public string Country { get; set; }
        public string University { get; set; }
        public string Specifications { get; set; }
    }
}
