

using System.ComponentModel.DataAnnotations;

namespace PMS_UserAPI.Models
{
    public class PatientAllergy
    {
        [Key]
        public int PatientAllergyId { get; set; }
        public string AllergyId { get; set; }
        public string AllergyType { get; set; }
        public bool? IsAllergyFatal { get; set; }
        public string Description { get; set; }
        //public int? UserId { get; set; }
        //public int? PatientId { get; set; }
        public string AllergyName { get; set; }
        public string ClinicalInformation { get; set; }
        //public string AllergyCode { get; set; }


    }
}
