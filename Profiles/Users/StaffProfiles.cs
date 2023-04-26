using AutoMapper;
using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Staff;

namespace server.Profiles
{
    public class StaffProfiles : Profile
    {
        public StaffProfiles()
        {
            CreateMap<StaffPost,Staff>();
            CreateMap<StaffPatch,Staff>();
        }
    }
}