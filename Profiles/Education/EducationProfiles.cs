using Models.DTO.EducationDTO;

namespace Profiles.Education;
public class EducationProfiles : AutoMapper.Profile
{
    public EducationProfiles()
    {
        CreateMap<Models.Domain.Education, EducationGet>();
        CreateMap<Models.Domain.Education, EducationPOST>().ReverseMap();
        CreateMap<Models.Domain.Education, EducationPatch>().ReverseMap();
    }
}
