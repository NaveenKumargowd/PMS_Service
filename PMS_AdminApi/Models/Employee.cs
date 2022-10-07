using System;
using System.ComponentModel.DataAnnotations;

namespace PMS_AdminApi.Models
{
    public class Employee
    {
        [Key]
        public int UserId { get; set; }

        public string Title { get; set; }

        public int? EmployeeId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string OldPassword { get; set; }

        public DateTime? DOB { get; set; }

        public DateTime? DOJ { get; set; }

        public string ContactNo { get; set; }

        public string Status { get; set; }

        public bool? IsActive { get; set; }

        public int? LoginAttempts { get; set; }

        public bool? IsLoggedin { get; set; }

        public bool? Is_SetDefault { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public string UserCode { get; set; }

        public string Role { get; set; }

        public string Gender { get; set; }

        public string Known_Languages { get; set; }
    }
}
