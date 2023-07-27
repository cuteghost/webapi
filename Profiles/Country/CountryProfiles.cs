using Models.DTO.CountryDTO;

namespace Profiles.Country;
public class CountryProfiles : AutoMapper.Profile
{
	public CountryProfiles()
	{
		CreateMap<Models.Domain.Country, CountryGET>();
		CreateMap<Models.Domain.Country, CountryPost>().ReverseMap();
		CreateMap<Models.Domain.Country, CountryPATCH>().ReverseMap();
    }
}
