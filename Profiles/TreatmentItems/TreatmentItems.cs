using Models.Domain;
using Models.DTO.TreatmentItemsDTO;

namespace Profiles.TreatmentProfiles;
public class TreatmentItemsProfile : AutoMapper.Profile
{
	public TreatmentItemsProfile()
	{
		CreateMap<Treatment, TreatmentItemsGET>().ReverseMap();
		CreateMap<Treatment, TreatmentItemsPOST>().ReverseMap();
		CreateMap<Treatment, TreatmentItemsPATCH>().ReverseMap();
    }
}
