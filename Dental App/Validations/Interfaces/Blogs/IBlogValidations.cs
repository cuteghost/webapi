using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Validations.Common.Validations;

namespace Dental_App.Validations.Interfaces.Blogs;
public interface IBlogValidations
{
    public Task<bool> ValidateBlogCreatorRole(long creatorId);
    public Task<bool> ValidateBlogChanger(long blogId, long changerId);
    public Task<ValidationModel> ValidatePOST(BlogPOST newblog);
    public Task<ValidationModel> ValidatePATCH(BlogPatch blog);
    public Task<ValidationModel> ValidateDELETE(long blogId, long creatorId);
}
