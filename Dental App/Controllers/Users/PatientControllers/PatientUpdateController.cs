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
        var validationResult = await _patientValidations.ValidatePATCHRequest(patientDTO);
        if (validationResult.ResultOfValidations == true)
        {
            var userDomain = _mapper.Map<User>(patientDTO);
            var patientDomain = _mapper.Map<Patient>(patientDTO);
            await _patientUpdateRepository.UpdatePatientAsync(userDomain, patientDomain);
        }
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}