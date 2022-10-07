using AutoMapper;
using PMS_Application.ViewModel;
using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;

namespace PMS_UserAPI.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public PatientRepository(DatabaseContext context /* IMapper mapper*/)
        {
            this._context = context;
            //this._mapper = mapper;
        }
        public int AddPatientInfo(PatientDetail patient)
        {
           
            var result = this._context.Patients.Add(patient);
            this._context.SaveChanges();
            return result.Entity.Id;
        }

      

        
    }
}
