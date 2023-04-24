using Dental_App.Models.Domain;
using Dental_App.Models.DTO.BlogDTO;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateBlogAsync(BlogPOST newBlogDTO)
    {
        var validationResult = await _blogValidations.ValidatePOST(newBlogDTO);
        if(validationResult.ResultOfValidations == true)
        {
            var newBlog = _mapper.Map<Blog>(newBlogDTO);
            await _blogCreate.CreateBlog(newBlog);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}
