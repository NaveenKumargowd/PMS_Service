namespace PMS_UserAPI.Models
{
    public class EmergencyContact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        //public string CountryCode { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string RelationShip { get; set; }
        public bool? NeedAccess { get; set; }
        //public int? UserId { get; set; }

    }
}
