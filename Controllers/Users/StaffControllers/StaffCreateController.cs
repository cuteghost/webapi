using Models.Domain;
using Models.DTO.UserDTO.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.StaffControllers;
public partial class StaffController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateStaffAsync(StaffPost newStaffDTO)
    {
        var validationResult = await _staffValidations.ValidatePOSTRequest(newStaffDTO);
        if (validationResult.ResultOfValidations == true)
        {
            var userDomain = _mapper.Map<User>(newStaffDTO);
            var staffDomain = _mapper.Map<Staff>(newStaffDTO);
            await _staffCreateRepository.CreateStaffAsync(userDomain, staffDomain);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}