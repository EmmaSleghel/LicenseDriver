﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseDRIVER.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(256)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public TypeOfUser Type { get; set; }
        public Guid Id { get; set; }

    }
    public enum TypeOfUser
    {
        Student=1,
        Teacher=2
    }
}
