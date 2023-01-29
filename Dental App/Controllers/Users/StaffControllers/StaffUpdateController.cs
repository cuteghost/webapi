using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.StaffControllers;

public partial class StaffController : Controller
{
    [HttpPatch]
    [Route("update/{UserId}/{StaffId}")]
    public async Task<IActionResult> UpdateStaffAsync(StaffPatch staffDTO,long UserId,long StaffId)
    {
        staffDTO.Id = UserId;
        staffDTO.StaffId = StaffId;
        if (await _staffValidations.ValidatePATCH(staffDTO) == true)
        {
            var userDomain = _mapper.Map<User>(staffDTO);
            var staffDomain = _mapper.Map<Staff>(staffDTO);

            await _staffUpdateRepository.UpdateStaffAsync(userDomain, staffDomain);

            return Ok("Staff member updated succesfuly!");
        }
        //return BadRequest(_staffValidations.validations.validation.validationMessage);
        return BadRequest();
    }
}