using Microsoft.AspNetCore.Mvc;
using PMS_UserAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Services
{
    public interface IAuthManager
    {
        Task<UserDTO> ValidateUser(Login login);
        Task<string> CreateToken();
    }
}
