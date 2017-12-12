using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public enum UserRole
    {
        Teacher=1,
        Student=2
    }
    public class User:IdentityUser
    {
        public User(UserRole userRole)
        {
            this.UserRole = userRole;
        }
        public UserRole UserRole { get; set; }
    }
}
