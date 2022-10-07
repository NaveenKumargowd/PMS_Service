using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_UserAPI.DTO;
using PMS_UserAPI.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        ////public async Task<IActionResult> GetLoginUserData([FromBody] Login login)
        //{
        //    try
        //    {
        //        var users = await _unitOfWork.Users.GetAll();
        //        var results = _mapper.Map<IList<UserDTO>>(users);

        //        var validUserData = results.FirstOrDefault(u => u.EmailId.Equals(login.Email) && u.Password.Equals(login.Password));
        //        if (validUserData!=null)
        //        {
        //             return Ok(validUserData);
        //        }

        //        return Unauthorized("User credentials are not valid");
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return StatusCode(500, "Internal Server error");
        //    }
        //}
    }
}
