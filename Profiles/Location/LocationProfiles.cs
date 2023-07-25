using Models.DTO.LocationDTO;

namespace Profiles.Location;
public class LocationProfiles : AutoMapper.Profile
{
	public LocationProfiles()
	{
		CreateMap<Models.Domain.Location, LocationGet>();
		CreateMap<Models.Domain.Location, LocationPost>().ReverseMap();
		CreateMap<Models.Domain.Location, LocationPatch>().ReverseMap();
    }
}
