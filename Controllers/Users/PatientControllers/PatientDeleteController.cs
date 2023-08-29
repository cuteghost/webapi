using Models.Domain;
using Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpDelete]
    [Route("delete/{UserId}")]
    public async Task<IActionResult> DeletePatientAsync([FromHeader]string Authorization, long userId)
    {
        var staffEmail = _iTokenService.GetEmailFromJWT(Authorization);
        if (await _iTokenService.IsStaff(staffEmail))
        {
            
            return await _patientDeleteRepository.DeletePatientAsync(userId) != 0 ? Ok("Done"): NotFound("Patient doesn't exists");
        }
        else
        {
            return Unauthorized("Your not a staff");
        }
    }
}