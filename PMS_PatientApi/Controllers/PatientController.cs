using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_Application.ViewModel;
using PMS_PatientApi.DTO;
using PMS_PatientApi.Exceptions;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using Serilog;
using System;

namespace PMS_PatientApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientRepository _patientService;
        private readonly IMapper _mapper;
        public PatientController(IPatientRepository patientService, IMapper mapper)
        {
            this._patientService = patientService;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("AddPatientInfo")]
        public IActionResult AddPatientInfo([FromBody] PatientDetail patient)
        {
           
            try
            {
                var result = this._patientService.AddPatientInfo(patient);
                
                if (result > 0)
                {
                    return Ok("Patient information added successfully ");
                   
                    
                }
                else
                  return   BadRequest();
                //return result > 0 ? Ok("Patient information added successfully") : BadRequest();
            }
            catch (CustomException ex)
            {
                Log.Error($"AddPatientInfo CustomException Error: {ex.Message}");
                return Content(ex.StatusCode.ToString(), ex.Message);
            }
            catch (Exception ex)
            {
                Log.Error($"AddPatientInfo Error: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the patient information");
            }
        }
     



    }
}
