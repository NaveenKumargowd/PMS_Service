using Microsoft.AspNetCore.Identity;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Repository
{
    public class UserRepository :GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {

        }
        public User GetLoginUserData(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            throw new NotImplementedException();
        }
    }
}
