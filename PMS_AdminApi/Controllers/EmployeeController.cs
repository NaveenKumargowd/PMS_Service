using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PMS_AdminApi.Models;
using PMS_AdminApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PMS_AdminApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            return _employeeService.GetEmployees();
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return _employeeService.GetEmployee(id);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public bool Post([FromBody] Employee value)
        {
            return _employeeService.SaveEmployee(value);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] Employee value)
        {
            return _employeeService.UpdateEmployee(id, value);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return _employeeService.DeleteEmployee(id);
        }
    }
}
