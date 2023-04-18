using Dental_App.Models.Domain;
using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Dental_App.Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpDelete]
    [Route("delete/{blogId}/{creatorId}")]
    public async Task<IActionResult> DeleteAsync(long blogId, long creatorId)
    {
        var validationResult = await _blogValidations.ValidateDELETE(blogId,creatorId);
        if(validationResult.ResultOfValidations == true)
        {
           await _blogDelete.DeleteBlog(blogId);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);    
    }
}
