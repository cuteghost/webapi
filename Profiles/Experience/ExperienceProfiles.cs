using Models.DTO.ExperienceDTO;

namespace Profiles.Experience;
public class ExperienceProfiles : AutoMapper.Profile
{
    public ExperienceProfiles()
    {
        CreateMap<Models.Domain.Experience, ExperienceGet>();
        CreateMap<Models.Domain.Experience, ExperiencePOST>().ReverseMap();
        CreateMap<Models.Domain.Experience, ExperiencePatch>().ReverseMap();
    }
}
