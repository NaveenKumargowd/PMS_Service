using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PMS_UserAPI.Data;
using PMS_UserAPI.DTO;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using PMS_UserAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuthManager _authManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountRepository _userRepository;
        private readonly IEmailService _emailService;
        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager, IMapper mapper,
            IAuthManager authManager, ILogger<AccountController> logger, 
            IAccountRepository userRepository, IEmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _userRepository = userRepository;
            _emailService = emailService;
            _configuration = configuration;
            
        }
        [HttpPost] 
        [Route("Register")]
        public async Task<object> RegisterUser([FromBody] SignUpModel signUpModel)
        {
            var result = await _userRepository.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                _userRepository.SendWelcomeEmail(signUpModel);
                return await Task.FromResult(new ResponseModel(ResponseCode.OK,"User Registered Successfully",null));
            }
             return await Task.FromResult(new ResponseModel(ResponseCode.Error, " ", result.Errors.Select(x => x.Description).ToArray()));
            //return Ok();
        }
        //public async Task<IActionResult> Register([FromBody] ApplicationUser userDTO)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        //var user = _mapper.Map<ApplicationUser>(userDTO);
        //        //user.Email = userDTO.Email;
        //        var result = await _userManager.CreateAsync(userDTO);
        //        if (!result.Succeeded)
        //        {
        //            return BadRequest("User Registration Failed");
        //        }
        //        await _userManager.AddToRoleAsync(userDTO, userDTO.Role);
        //       return Accepted(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Problem( "Something went wrong error", statusCode: 500);
        //    }
        //}
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var verifiedUserDTO = await _authManager.ValidateUser(login);
                if (verifiedUserDTO == null)
                {
                    return Unauthorized();
                }
                verifiedUserDTO.UserCode = await _authManager.CreateToken();
                return Accepted(new ResponseModel(ResponseCode.OK,"", verifiedUserDTO));
            }
            catch (Exception ex)
            {
                return Problem("Something went wrong error", statusCode: 500);
            }
        }

        [HttpPost("ChangePassword")]
        public async Task<Object> ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                user.IsPasswordChanged = "true";
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _userRepository.SendChangePasswordEmail(user);
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Password updated successfully. please login", null));
                }
                else
                {

                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Password change is failedPlease try again", null));
                }
            }
            else
            {
                return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Internal Server Error", null));

            }

        }

        [HttpPost("ForgotPassword")]
        public async Task<object> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                //string passwordhash= _userManager.PasswordHasher
                await _userManager.RemovePasswordAsync(user);
                var result = await _userManager.AddPasswordAsync(user, _configuration["Password"]);
                user.IsPasswordChanged = "false";
                await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _userRepository.SendForgotPasswordEmail(user, _configuration["Password"]);
                    return await Task.FromResult(new ResponseModel(ResponseCode.OK, "Password sent to email and please change the password once you login", null));
                }
                else
                {
                    return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Error in update password, please try after sometime", null));
                }
            }

            return await Task.FromResult(new ResponseModel(ResponseCode.Error, "Email id not found", null));


        }



        

    }
}
