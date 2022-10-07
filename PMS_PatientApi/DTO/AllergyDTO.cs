namespace PMS_PatientApi.DTO
{
    public class AllergyDTO
    {

        public string AllergyID { get; set; }
        public string AllergyType { get; set; }
        public string AllergyName { get; set; }
        public string Description { get; set; }
        public string ClinicalInformation { get; set; }
        public bool IsAllergyFatal { get; set; }

    }
}
