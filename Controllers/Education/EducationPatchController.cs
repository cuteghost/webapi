using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.DTO.EducationDTO;
using webapi.Models.Domain;

namespace Controllers.Users.EducationControllers;

public partial class EducationController : Controller
{
    [HttpPatch]
    [Authorize]
    [Route("update/{educationId}/{creatorId}")]
    public async Task<IActionResult> UpdateEducationAsync(long educationId, long creatorId, EducationPatch blogDTO)
    {
        var education = _mapper.Map<Education>(blogDTO);
        await _educationUpdate.UpdateEducation(education);
        return await _responseService.Response(200,"The education updated successfully!");
    }
}
