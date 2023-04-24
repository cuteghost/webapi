using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using Dental_App.Validations.Common.Validations;
using Dental_App.Validations.Interfaces.Blogs;

namespace Dental_App.Validations.Classes.Blogs;
public class BlogValidations : IBlogValidations
{
    private readonly IBlogsRead _blogReadService;
    private readonly IStaffRead _staffReadService;
    public  IValidationsService _validationsService { get; set; }
    public BlogValidations(IBlogsRead blogReadService,IStaffRead staffReadService, IValidationsService validationsService)
    {
        _blogReadService = blogReadService;
        _staffReadService = staffReadService;
        _validationsService = validationsService;
    }

    public async Task<ValidationModel> ValidatePOST(BlogPOST newBlog)
    {
        var validationResult = _validationsService.ValidateFieldsLength(newBlog,new string[] {"CreatorId"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        if(!await ValidateBlogCreatorRole(newBlog.CreatorId))
        {
            return new ValidationModel
            {
                ValidationMessage = $"You are unauthorized to create the blog.",
                StatusCode = 401,
                ResultOfValidations = false
            };
        }
        return new ValidationModel
        {
            ValidationMessage = $"Blog created successfuly!",
            StatusCode = 201,
            ResultOfValidations = true
        };
    }

    public async Task<ValidationModel> ValidatePATCH(BlogPatch blog)
    {
        var validationResult = _validationsService.ValidateFieldsLength(blog,new string[] {"Id","CreatorId"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        if (await ValidateBlogChanger(blog.Id, blog.CreatorId) == false)
        {
            return new ValidationModel
            {
                ValidationMessage = $"You are unauthorized to modify this blog.",
                StatusCode = 401,
                ResultOfValidations = false
            };
        }
        return new ValidationModel
        {
            ValidationMessage = $"Blog updated successfuly!",
            StatusCode = 201,
            ResultOfValidations = true
        };
    }
    public async Task<ValidationModel> ValidateDELETE(long blogId, long creatorId)
    {
        if (await ValidateBlogChanger(blogId, creatorId) == false)
        {
            return new ValidationModel
            {
                ValidationMessage = $"You are unauthorized to delete this blog.",
                StatusCode = 401,
                ResultOfValidations = false
            };
        }
        return new ValidationModel
        {
            ValidationMessage = $"You have deleted deleted blog.",
            StatusCode = 204,
            ResultOfValidations = false
        };
    }
    public async Task<bool> ValidateBlogCreatorRole(long creatorId)
    {
        if(creatorId == 0)
        {
            return false;
        }
        if (await _staffReadService.GetStaffUserId(creatorId) == 0)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateBlogChanger(long blogId, long changerId)
    {
        var blog = await _blogReadService.GetBlogDetails(blogId);
        if (changerId == 0)
        {
            return false;
        }
        if (blog.Creator.Id != changerId)
        {
            return false;
        }
        return true;
    }
}
