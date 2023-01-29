using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpPatch]
    [Route("update/{UserId}/{PatientId}")]
    public async Task<IActionResult> UpdatePatientAsync(PatientPATCH patientDTO, long UserId, long PatientId)
    {
        patientDTO.Id = UserId;
        patientDTO.PatientId = PatientId;
        if (await _patientValidations.ValidatePATCH(patientDTO) == true)
        {
            var userDomain = _mapper.Map<User>(patientDTO);
            var patientDomain = _mapper.Map<Patient>(patientDTO);

            await _patientUpdateRepository.UpdatePatientAsync(userDomain, patientDomain);

            return Ok("Patient updated succesfuly!");
        }
        //return BadRequest(_staffValidations.validations.validation.validationMessage);
        return BadRequest();
    }
}