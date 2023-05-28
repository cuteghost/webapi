using AutoMapper;
using Models.Domain;
using Models.DTO.UserDTO.Staff;
using Models.DTO.AuthDTO;
using Models.DTO.UserDTO.Patient;

namespace Profiles.Users;

    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<StaffPost, User>();
            CreateMap<StaffPatch, User>();
            CreateMap<PatientPOST, User>();
            CreateMap<PatientPATCH, User>();
            CreateMap<LoginDTO, User>().ReverseMap();
            CreateMap<LoginDTO, LoginPOSTDTO>().ReverseMap();
            
        }
    }

