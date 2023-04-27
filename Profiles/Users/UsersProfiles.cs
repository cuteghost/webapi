using AutoMapper;
using Models.Domain;
using Models.DTO.UserDTO;
using Models.DTO.UserDTO.Staff;

namespace Profiles.Users;

    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<StaffPost, User>();
            CreateMap<StaffPatch, User>();
        }
    }

