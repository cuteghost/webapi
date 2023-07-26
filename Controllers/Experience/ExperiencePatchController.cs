using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.DTO.ExperienceDTO;

namespace Controllers.Users.ExperienceControllers;

public partial class ExperienceController : Controller
{
    [HttpPatch]
    // [Authorize]
    [Route("update/{experienceId}/{creatorId}")]
    public async Task<IActionResult> UpdateExperienceAsync(long experienceId, long creatorId, ExperiencePatch blogDTO)
    {
        var experience = _mapper.Map<Experience>(blogDTO);
        await _experienceUpdate.UpdateExperience(experience);
        return await _responseService.Response(200,"The experience updated successfully!");
    }
}
