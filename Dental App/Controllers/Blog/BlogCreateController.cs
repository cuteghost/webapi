using Dental_App.Models.Domain;
using Dental_App.Models.DTO.BlogDTO;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Dental_App.Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateBlogAsync(BlogPOST newBlogDTO)
    {
        if(await _blogValidations.ValidatePOST(newBlogDTO) == true)
        {
            var newBlog = _mapper.Map<Blog>(newBlogDTO);
            await _blogCreate.CreateBlog(newBlog);
            return Ok(newBlog.Id);
        }
        else
        {
            return BadRequest();
        }
    }
}
