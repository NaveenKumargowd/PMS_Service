using AutoMapper;
using PMS_UserAPI.DTO;
using PMS_UserAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS_UserAPI.Configurations
{
    public class MapperInitializer:Profile
    {
        public MapperInitializer()
        {
            CreateMap<Notes, NotesDTO>().ReverseMap();
            CreateMap<Notes, CreateNotesDTO>().ReverseMap();
        }
    }
}
