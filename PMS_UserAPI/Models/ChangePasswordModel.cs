﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Models
{
    public class ChangePasswordModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
    }
}
