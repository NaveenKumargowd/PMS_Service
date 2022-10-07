using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PMS_UserAPI.Data;
using PMS_UserAPI.DTO;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PMS_UserAPI.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ApplicationUser _user;

        public AuthManager(UserManager<ApplicationUser> userManager, IConfiguration configuration,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            if (claims != null)
            {
                var tokenOptions = GenerateTokenoptions((SigningCredentials)signingCredentials, claims);

                return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            }
            return null;
        }

        private JwtSecurityToken GenerateTokenoptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings.GetSection("Key").Value;
            var issuer = jwtSettings.GetSection("Issuer").Value;
            var expiration = DateTime.Now.AddDays(10);

            var token = new JwtSecurityToken(
                issuer: issuer,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            if(_user!=null){
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,_user.Email)
            };
                var roles = await _userManager.GetRolesAsync(_user);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                return claims;
            }
            return null;
        }
        private object GetSigningCredentials()
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = _configuration.GetValue<string>("Jwt:Key");
            var issuer = _configuration.GetValue<string>("Jwt:Issuer");

            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            
        }

        public async Task<UserDTO> ValidateUser(Login login)
        {
            UserDTO userDTO = new UserDTO();
            _user = await _userManager.FindByNameAsync(login.Email);
            var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, true);
            if (result.Succeeded)
            {
                var roles = (await _userManager.GetRolesAsync(_user)).ToList();

                if(_user != null)
                {
                    
                    userDTO.Title = _user.Title.ToString();
                    userDTO.UserId = Convert.ToInt32(_user.Id);
                    userDTO.Username = (_user.FirstName.ToString() + " " + _user.LastName.ToString());
                    userDTO.EmailId = _user.Email.ToString();
                    userDTO.Is_SetDefault = Convert.ToBoolean(_user.IsPasswordChanged);
                    userDTO.Role = _user.Role.ToString();
                    userDTO.Roles = roles.ToList();

                }
            }
            return userDTO;
        }
    }
}
