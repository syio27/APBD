﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorPatientAPI.Models.DTOs
{
    public class RegisterRequest
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
