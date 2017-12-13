using Services.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IUserService
    {
        UserDto GetUserById(Guid id);
       void CreateUser(UserDto user);
    }
}
