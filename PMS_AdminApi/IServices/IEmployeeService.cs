using System.Collections.Generic;
using PMS_AdminApi.Models;

namespace PMS_AdminApi.Services
{
    public interface IEmployeeService
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        bool SaveEmployee(Employee value);
        bool UpdateEmployee(int id, Employee value);
        bool DeleteEmployee(int id);
    }
}
