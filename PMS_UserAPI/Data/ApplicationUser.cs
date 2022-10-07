using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Data
{
    public class ApplicationUser:IdentityUser<int>
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IsPasswordChanged { get; set; }
        public string Role { get; set; }
    }
}
