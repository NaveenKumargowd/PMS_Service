using System;

namespace PMS_PatientApi.DTO
{
    public class PatientAllergyDTO
    {

        public int Id { get; set; }
        public int? Patientid { get; set; }
        public string Allergyid { get; set; }
        public string Allergytype { get; set; }
        public string Allergydescription { get; set; }
        public string Allergyclinicalinformation { get; set; }
        public bool Allergyfatal { get; set; }
        public bool Isactive { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public int? Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }













    }
}
