using Models.Domain;
using Models.DTO.UserDTO.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.StaffControllers;

public partial class StaffController : Controller
{
    [HttpPatch]
    [Route("update/{UserId}/{StaffId}")]
    public async Task<IActionResult> UpdateStaffAsync(StaffPatch staffDTO,long UserId,long StaffId)
    {
        staffDTO.Id = UserId;
        staffDTO.StaffId = StaffId;
        var validationResult = await _staffValidations.ValidatePATCHRequest(staffDTO);
        if (validationResult.ResultOfValidations == true)
        {
            var userDomain = _mapper.Map<User>(staffDTO);
            var staffDomain = _mapper.Map<Staff>(staffDTO);
            staffDomain.User = userDomain;
            await _staffUpdateRepository.UpdateStaffAsync(userDomain, staffDomain);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}