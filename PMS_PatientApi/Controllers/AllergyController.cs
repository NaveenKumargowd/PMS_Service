using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_PatientApi.Exceptions;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using Serilog;
using System;

namespace PMS_PatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private readonly IPatientAllergyRepository _patientallergy;
        private readonly IMapper _mapper;
        public AllergyController(IPatientAllergyRepository patientallergy, IMapper mapper)
        {
            this._patientallergy = patientallergy;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("AddAllergyInfo")]
        public IActionResult AddAllergyInfo([FromBody] PatientAllergy alergy)
        {
            
            try
            {
                var result = this._patientallergy.SavePatientAllergy(alergy);

                if (result > 0)
                {
                    return Ok("Patient allergy details added successfully ");
                }
                else
                    return BadRequest();
               
            }
            catch (CustomException ex)
            {
                Log.Error($"AddPatientInfo CustomException Error: {ex.Message}");
                return Content(ex.StatusCode.ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"AddPatientInfo Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the patient allergy information");
            }
        }

    }
}
