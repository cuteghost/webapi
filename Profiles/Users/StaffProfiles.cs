using AutoMapper;
using Models.Domain;
using Models.DTO.UserDTO.Staff;

namespace server.Profiles
{
    public class StaffProfiles : Profile
    {
        public StaffProfiles()
        {
            CreateMap<StaffPost,Staff>().ReverseMap();
            CreateMap<StaffPatch,Staff>().ReverseMap();
            CreateMap<Staff,StaffGet>().ReverseMap();
        }
    }
}