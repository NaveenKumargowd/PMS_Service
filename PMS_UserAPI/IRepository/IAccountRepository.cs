using Microsoft.AspNetCore.Identity;
using PMS_UserAPI.Data;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.IRepository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel model);

        void SendWelcomeEmail(SignUpModel model);
        void SendForgotPasswordEmail(ApplicationUser model, string password);
        void SendChangePasswordEmail(ApplicationUser model);
    }
}
