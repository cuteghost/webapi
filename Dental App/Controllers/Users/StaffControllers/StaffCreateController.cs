using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Staff;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.StaffControllers;
public partial class StaffController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateStaffAsync(StaffPost newStaffDTO)
    {
        if (await _staffValidations.ValidatePOST(newStaffDTO) == true)
        {
            var userDomain = _mapper.Map<User>(newStaffDTO);
            var staffDomain = _mapper.Map<Staff>(newStaffDTO);

            await _staffCreateRepository.CreateStaffAsync(userDomain, staffDomain);

            return Ok("Staff member added successfuly!");
        }
        //return BadRequest(_staffValidations.validations.validation.validationMessage);
        return BadRequest();
    }
}