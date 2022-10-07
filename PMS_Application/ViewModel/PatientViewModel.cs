using System;
using System.Collections.Generic;
using System.Text;

namespace PMS_Application.ViewModel
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public int? Patientid { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Languages { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }
        //public EmergencyContactInfoModel EmergencyContact { get; set; }
        //public List<PatientAllergyModel> PatientAllergy { get; set; }







    }
}
