using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static PMS_UserAPI.Data.IdentityModel;

namespace PMS_UserAPI.Repository
{
    public class AccountsRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IEmailService _emailService;

        public AccountsRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration, RoleManager<ApplicationRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
            _emailService = emailService;
           
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser()
            {
                Title = model.Title,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                DateOfBirth = model.DateOfBirth,
                ContactNo = model.ContactNumber,
                Role = model.Role,
                IsPasswordChanged = "true"
            };

            var roleExist = await _roleManager.RoleExistsAsync(user.Role);
            if (!roleExist)
            {
                await _roleManager.CreateAsync(new ApplicationRole
                {
                    Name = model.Role
                });
            }

            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, model.Role);
            return result;
        }

        public async void SendWelcomeEmail(SignUpModel model)
        {
            string Subject = "Welcome to CT Hospital";
            string Body = $" Hi {model.Title} {model.FirstName} {model.LastName} \n \n Welome to CT General Hospital. \n Your Registration is successfull. \n \n \n Regards \n CT Admin";

            await _emailService.SendEmail(model.Email, Subject, Body);
        }
        public async void SendForgotPasswordEmail(ApplicationUser model, string password)
        {
            string Subject = "Default Password";
            string Body = $" Hi {model.Title} {model.FirstName} {model.LastName} \n\n Here is your default Password : {password}   \n Please change the password once you login for first time. \n\n Regards \n CT Admin";

            await _emailService.SendEmail(model.Email, Subject, Body);

        }
        public async void SendChangePasswordEmail(ApplicationUser model)
        {
            string Subject = "Password Changed Successfully";
            string Body = $" Hi {model.Title} {model.FirstName} {model.LastName} \n\n Your  Password is updated successfully.  \n Kindly login again \n \n Regards \n CT Admin";

            await _emailService.SendEmail(model.Email, Subject, Body);

          
        }
    }
}
