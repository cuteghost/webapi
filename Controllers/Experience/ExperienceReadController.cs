using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.ExperienceControllers;

public partial class ExperienceController : Controller
{
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetAllExperiencesAsync()
    {
        var experiences = await _experienceRead.GetAllExperiences();
        return Ok(experiences);
    }
    [HttpGet]
    [Route("get/{Id}")]
    public async Task<IActionResult> GetBlogAsync(long Id)
    {
        var experience = await _experienceRead.GetExperience(Id);
        return Ok(experience);
    }
}
