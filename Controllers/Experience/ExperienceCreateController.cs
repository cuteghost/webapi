using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.DTO.ExperienceDTO;

namespace Controllers.Users.ExperienceControllers;

public partial class ExperienceController : Controller
{
    [HttpPost]
    // [Authorize]
    [Route("create")]
    public async Task<IActionResult> CreateExperienceAsync(ExperiencePOST newExperienceDTO)
    {
        var newExperience = _mapper.Map<Experience>(newExperienceDTO);
        await _experienceCreate.CreateExperience(newExperience);
        return await _responseService.Response(201,"Experience added successfully!");
    }
}
