using PMS_UserAPI.Data;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Models;

namespace PMS_UserAPI.Repository
{
    public class EmergencyContactInfoRepository : IEmergencyContactInfoRepository
    {
        private readonly DatabaseContext _context;
        //private readonly IMapper _mapper;
        public EmergencyContactInfoRepository(DatabaseContext context /* IMapper mapper*/)
        {
            this._context = context;
            //this._mapper = mapper;
        }



       
        public int SaveEmergencyContactInfo(EmergencyContact emergency)
        {

            var result = this._context.Emergencies.Add(emergency);
            this._context.SaveChanges();
            return result.Entity.Id;
        }

        
    }
}
