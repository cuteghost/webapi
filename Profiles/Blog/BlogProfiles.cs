using Models.DTO.BlogDTO;

namespace Profiles.Blog;
public class BlogProfiles : AutoMapper.Profile
{
	public BlogProfiles()
	{
		CreateMap<Models.Domain.Blog, BlogGet>();
		CreateMap<Models.Domain.Blog, BlogPOST>().ReverseMap();
		CreateMap<Models.Domain.Blog, BlogPatch>().ReverseMap();
    }
}
