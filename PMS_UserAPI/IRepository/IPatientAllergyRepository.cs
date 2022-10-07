using PMS_UserAPI.Models;
using System.Collections.Generic;

namespace PMS_UserAPI.IRepository
{
    public interface IPatientAllergyRepository
    {



        int SavePatientAllergy(PatientAllergy model);
        //void UpdatePatientAllergy(PatientAllergy model);
        //List<PatientAllergy> GetPatientAllergy(int patientId);

    }
}
