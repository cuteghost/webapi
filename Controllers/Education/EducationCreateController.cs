using Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Models.DTO.EducationDTO;

namespace Controllers.Users.EducationControllers;

public partial class EducationController : Controller
{
    [HttpPost]
    // [Authorize]
    [Route("create")]
    public async Task<IActionResult> CreateEducationAsync(EducationPOST newEducationDTO)
    {
        var newEducation = _mapper.Map<Education>(newEducationDTO);
        await _educationCreate.CreateEducation(newEducation);
        return await _responseService.Response(201,"Education added successfully!");
    }
}
