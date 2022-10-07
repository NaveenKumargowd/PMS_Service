using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS_UserAPI.IRepository;
using PMS_UserAPI.Repository;

namespace PMS_PatientApi
{
    public static class Injection
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection service, IConfiguration configuration)
        {
            
            //service.AddTransient<IEmergencyContactInfoRepository, EmergencyContactInfoRepository>();
            //service.AddTransient<IPatientAllergyRepository, PatientAllergyRepository>();
            //service.AddTransient<IUserRepository, UserRepository>();
            //service.AddTransient<IHospitalUserRpository, HospitalUserRepository>();
            //service.AddTransient<IAppointmentRepository, AppointmentRepository>();
            //service.AddTransient<IPatientDiagnosisRepository, PatientDiagnosisRepository>();
            //service.AddTransient<IPatientProcedureRepository, PatientProcedureRepository>();
            //service.AddTransient<IPatientMedicationRepository, PatientMedicationRepository>();
            //service.AddTransient<IVisitorRepository, VisitorRepository>();
            //service.AddTransient<IPatientManagementRepository, PatientManagementRepository>();
            //service.AddTransient<IUserRegisterRepository, UserRegisterRepository>();

            //service.AddTransient<INotesRepository, NotesRepository>();

            //service.AddTransient<IDiagnosisRepository, DiagnosisRepository>();
            //service.AddTransient<IProcedureRepository, ProcedureRepository>();
            //service.AddTransient<IDrugDataRepository, DrugDataRepository>();

            return service;
        }
    }
}
