using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controllers.Users.ExperienceControllers;

public partial class ExperienceController : Controller
{
    [HttpDelete]
    // [Authorize]
    [Route("delete/{experienceId}/{creatorId}")]
    public async Task<IActionResult> DeleteAsync(long experienceId, long creatorId)
    {
        await _experienceDelete.DeleteExperience(experienceId);
        return await _responseService.Response(200,"The experience deleted successfully!");    
    }
}
