using PMS_UserAPI.Models;

namespace PMS_UserAPI.IRepository
{
    public interface IEmergencyContactInfoRepository
    {

        int SaveEmergencyContactInfo(EmergencyContact emergency);
        //int UpdateEmergencyContactInfo(EmergencyContact emergency);
        //EmergencyContact GetEmergencyContactInfoById(int infoId);

    }
}
