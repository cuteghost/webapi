using AutoMapper;
using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO;
using Dental_App.Models.DTO.UserDTO.Staff;

namespace Dental_App.Profiles.Users;

    public class UsersProfiles : Profile
    {
        public UsersProfiles()
        {
            CreateMap<StaffPost, User>();
            CreateMap<StaffPatch, User>();
        }
    }

