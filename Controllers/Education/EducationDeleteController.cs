using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Controllers.Users.EducationControllers;

public partial class EducationController : Controller
{
    [HttpDelete]
    [Authorize]
    [Route("delete/{educationId}/{creatorId}")]
    public async Task<IActionResult> DeleteAsync(long educationId, long creatorId)
    {
        await _educationDelete.DeleteEducation(educationId);
        return await _responseService.Response(200,"The education deleted successfully!");    
    }
}
