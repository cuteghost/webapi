using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Profiles.TreatmentProfiles;
public class TreatmentProfile : AutoMapper.Profile
{
	public TreatmentProfile()
	{
		CreateMap<Treatment, TreatmentGET>().ReverseMap();
		CreateMap<Treatment, TreatmentPOST>().ReverseMap();
		CreateMap<Treatment, TreatmentPATCH>().ReverseMap();
    }
}
