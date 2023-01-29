using AutoMapper;
using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Patient;

namespace Dental_App.Profiles.Users;
public class PatientsProfiles : Profile
{
	public PatientsProfiles()
	{
        CreateMap<PatientPOST, Patient>();
        CreateMap<PatientPATCH, Patient>();
    }
}
