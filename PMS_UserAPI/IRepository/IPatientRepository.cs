using PMS_Application.ViewModel;
using PMS_UserAPI.Models;
using System.Threading.Tasks;

namespace PMS_UserAPI.IRepository
{
    public interface IPatientRepository
    {
       int AddPatientInfo(PatientDetail patient);
        //int UpdatePatientInfo(PatientDetail patient);
        //PatientDetail GetPatientInfoById(int patientId);
       
        //DataTable GetAllPatients();






    }
}
