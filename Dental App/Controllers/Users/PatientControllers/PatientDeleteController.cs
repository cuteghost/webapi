using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpDelete]
    [Route("delete/{AdminId}/{UserId}")]
    public async Task<IActionResult> DeletePatientAsync(long AdminId, long UserId)
    {
        if (await _patientValidations.ValidateDELETE(AdminId, UserId) == true)
        {
            await _patientDeleteRepository.DeletePatientAsync(AdminId, UserId);
            return Ok("Patient deleted successfuly!");
        }
        //return BadRequest(_staffValidations.validations.validation.validationMessage);
        return BadRequest();
    }
}