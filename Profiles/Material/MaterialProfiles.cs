using Models.Domain;
using Models.DTO.MaterialDTO;

namespace Profiles.TreatmentProfiles;
public class MaterialProfile : AutoMapper.Profile
{
	public MaterialProfile()
	{
		CreateMap<Treatment, MaterialGET>().ReverseMap();
		CreateMap<Treatment, MaterialPOST>().ReverseMap();
		CreateMap<Treatment, MaterialPATCH>().ReverseMap();
    }
}
