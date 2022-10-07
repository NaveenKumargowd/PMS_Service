using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_PatientApi.Exceptions;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using PMS_UserAPI.Repository;
using Serilog;
using System;

namespace PMS_PatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyController : ControllerBase
    {
        private readonly IEmergencyContactInfoRepository _patientemergency;
        private readonly IMapper _mapper;
        public EmergencyController(IEmergencyContactInfoRepository patientallergy, IMapper mapper)
        {
            this._patientemergency = patientallergy;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("EmergencyInfo")]
        public IActionResult EmergencyInfo([FromBody] EmergencyContact emergent)
        {
            try
            {
                var result = this._patientemergency.SaveEmergencyContactInfo(emergent);

                if (result > 0)
                {
                    return Ok("Emergency Contact details added successfully ");
                }
                else
                    return BadRequest();
                //return result > 0 ? Ok("Patient information added successfully") : BadRequest();
            }
            catch (CustomException ex)
            {
                Log.Error($"AddEmergencyinfo CustomException Error: {ex.Message}");
                return Content(ex.StatusCode.ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"AddEmergencyinfo Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the patient Emergency information");
            }
        }
    }
}
