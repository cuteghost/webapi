using Dental_App.Models.Domain;
using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Dental_App.Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpPatch]
    [Route("update/{blogId}/{creatorId}")]
    public async Task<IActionResult> UpdateBlogAsync(long blogId, long creatorId, BlogPatch blogDTO)
    {
        if (await _blogValidations.ValidatePATCH(blogDTO) == true)
        {
            var blog = _mapper.Map<Blog>(blogDTO);
            await _blogUpdate.UpdateBlog(blog);
            return Ok(blog.Id);
        }
        else
        {
            return BadRequest();
        }
    }
}
