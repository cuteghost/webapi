using Dental_App.Models.DTO.BlogDTO;

namespace Dental_App.Validations.Interfaces.Blogs;
public interface IBlogValidations
{
    public Common.Validations validations { get; set; }
    public Task<bool> ValidateCreator(long creatorId);
    public Task<bool> ValidateCreator(long blogId, long creatorId);
    public Task<bool> ValidatePOST(BlogPOST newblog);
    public Task<bool> ValidatePATCH(BlogPatch blog);
    public Task<bool> ValidateDELETE(long blogId, long creatorId);
}
