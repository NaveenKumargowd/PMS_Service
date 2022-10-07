using AutoMapper;
using PMS_Application.ViewModel;
using PMS_PatientApi.DTO;
using PMS_UserAPI.Models;

namespace PMS_PatientApi.Mapping
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
           
            CreateMap<PatientDTO, PatientViewModel>().ReverseMap();
            CreateMap<PatientViewModel, PatientDetail>().ReverseMap();
            
        }
    }
}
