using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Profiles.AppointmentProfiles;
public class AppointmentProfile : AutoMapper.Profile
{
	public AppointmentProfile()
	{
		CreateMap<Appointment, AppointmentGET>().ReverseMap();
		CreateMap<Appointment, AppointmentPOST>().ReverseMap();
		CreateMap<Appointment, AppointmentPATCH>().ReverseMap();
    }
}
