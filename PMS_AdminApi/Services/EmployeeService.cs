using System;
using System.Collections.Generic;
using System.Linq;
using PMS_AdminApi.Models;
using PMS_AdminApi.Services;

namespace PMS_AdminApi.Repository
{
    public class EmployeeService : IEmployeeService
    {
        private AdminContext _context;

        public EmployeeService(AdminContext context)
        {
            _context = context;
        }
        public List<Employee> GetEmployees()
        {
            List<Employee> empList;
            try
            {
                empList = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return empList;
        }

        public Employee GetEmployee(int id)
        {
            Employee emp;
            try
            {
                emp = _context.Employees.Find(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return emp;
        }

        public bool SaveEmployee(Employee value)
        {
            try
            {
                _context.Employees.Add(value);
                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool UpdateEmployee(int id, Employee value)
        {
            try
            {
                Employee employee = _context.Employees.Find(x => x.Id == id);
                if (employee == null)
                {
                    _context.Employees.Update(value);
                    _context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                throw;
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                Employee employee = _context.Employees.Find(x => x.Id == id);
                _context.Employees.Remove(employee);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw;
                return false;
            }
        }
    }
}
