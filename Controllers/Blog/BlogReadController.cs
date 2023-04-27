using Models.Domain;
using Models.DTO.BlogDTO;
using Repository.Interfaces.BlogsInterfaces;
using Validations.Interfaces.Blogs;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.BlogControllers;

public partial class BlogController : Controller
{
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAllBlogsAsync()
    {
        var blogs = await _blogRead.GetAllTitles();
        return Ok(blogs);
    }
    [HttpGet]
    [Route("get/{Id}")]
    public async Task<IActionResult> GetBlogAsync(long Id)
    {
        var blog = await _blogRead.GetBlogDetails(Id);
        return Ok(blog);
    }
}
