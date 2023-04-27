using Models.Domain;
using Models.DTO.BlogDTO;
using Repository.Interfaces.BlogsInterfaces;
using Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.BlogControllers;

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
