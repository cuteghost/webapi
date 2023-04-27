using AutoMapper;
using Models.Domain;
using Models.DTO.UserDTO.Patient;

namespace Profiles.Users;
public class PatientsProfiles : Profile
{
	public PatientsProfiles()
	{
        CreateMap<PatientPOST, Patient>();
        CreateMap<PatientPATCH, Patient>();
    }
}
