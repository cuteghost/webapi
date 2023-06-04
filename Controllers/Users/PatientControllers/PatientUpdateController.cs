using Models.Domain;
using Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpPatch]
    [Route("update")]
    [Authorize]
    public async Task<IActionResult> UpdatePatientAsync(PatientPATCH patientDTO, [FromHeader] string Authorization )
    {
        var email = _iTokenService.GetEmailFromJWT(Authorization);
        var patient = await _patientReadRepository.ReadPatientByEmail(email,"");
        
        patientDTO.Id = patient.User.Id;
        patientDTO.PatientId = patient.PatientId;
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