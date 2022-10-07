namespace PMS_PatientApi.DTO
{
    public class PatientEmergencyDTO
    {

        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int RelationshipId { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public bool? Isportalaccessible { get; set; }
        public bool anyKnownAllergy { get; set; }

    }
}
