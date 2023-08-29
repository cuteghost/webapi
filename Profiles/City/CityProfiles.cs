using Models.DTO.CityDTO;

namespace Profiles.City;
public class CityProfiles : AutoMapper.Profile
{
	public CityProfiles()
	{
		CreateMap<Models.Domain.City, CityGET>().ReverseMap();
		CreateMap<Models.Domain.City, CityPost>().ReverseMap();
		CreateMap<Models.Domain.City, CityPATCH>().ReverseMap();
    }
}
