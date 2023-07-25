using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.EducationControllers;

public partial class EducationController : Controller
{
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAllEducationsAsync()
    {
        var educations = await _educationRead.GetAllEducations();
        return Ok(educations);
    }
    [HttpGet]
    [Route("get/{Id}")]
    public async Task<IActionResult> GetBlogAsync(long Id)
    {
        var education = await _educationRead.GetEducation(Id);
        return Ok(education);
    }
}
