using System;

namespace PMS_UserAPI.Models
{
    public class PatientDetail
    {
        //public Patient()
        //{
        //    Patientallergies = new HashSet<Patientallergy>();
        //}

        
        public int Id { get; set; }
        public int? Patientid { get; set; }
        public string Race { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public DateTime DOB { get; set; }

        public string LastName { get; set; }
        public string Ethnicity { get; set; }
        public string Languages { get; set; }
        public string Address { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }

        public string ContactNo { get; set; }
        public int Age { get; set; }
        public string gender { get; set; }
        
        public string Email { get; set; }

        //public string City { get; set; }
        //public string State { get; set; }
        //public string Country { get; set; }
        //public string Postalcode { get; set; }
        //public int? Emergencycontactid { get; set; }

       


    }
}
