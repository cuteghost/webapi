using AutoMapper;
using Models.Domain;
using Models.DTO.AuthDTO;
using Models.DTO.UserDTO.Patient;

namespace Profiles.Users;
public class PatientsProfiles : Profile
{
	public PatientsProfiles()
	{
        CreateMap<PatientGET, Patient>().ReverseMap();
        CreateMap<PatientPOST, Patient>().ReverseMap();
        CreateMap<PatientPATCH, Patient>().ReverseMap();
    }
}
