using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.IRepository
{
    public interface IUserRepository
    {
        User GetLoginUserData(string email, string password);
    }
}
