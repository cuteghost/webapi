using Models.Domain;
using Models.DTO.BlogDTO;
using Repository.Interfaces.BlogsInterfaces;
using Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpPatch]
    [Route("update/{blogId}/{creatorId}")]
    public async Task<IActionResult> UpdateBlogAsync(long blogId, long creatorId, BlogPatch blogDTO)
    {
        var validationResult = await _blogValidations.ValidatePATCH(blogDTO);
        if(validationResult.ResultOfValidations == true)
        {
            var blog = _mapper.Map<Blog>(blogDTO);
            await _blogUpdate.UpdateBlog(blog);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}
