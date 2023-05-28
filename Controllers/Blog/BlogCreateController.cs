using Models.Domain;
using Models.DTO.BlogDTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpPost]
    [Authorize]
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
