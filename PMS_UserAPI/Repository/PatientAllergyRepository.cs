using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;
using System.Collections.Generic;

namespace PMS_UserAPI.Repository
{
    public class PatientAllergyRepository : IPatientAllergyRepository
    {
        private readonly DatabaseContext _context;
        //private readonly IMapper _mapper;
        public PatientAllergyRepository(DatabaseContext context /* IMapper mapper*/)
        {
            this._context = context;
            //this._mapper = mapper;
        }
       


        public int SavePatientAllergy(PatientAllergy allergy)
        {

            var result = this._context.Allergys.Add(allergy);
            this._context.SaveChanges();
            return result.Entity.PatientAllergyId;
        }

     
    }
}
