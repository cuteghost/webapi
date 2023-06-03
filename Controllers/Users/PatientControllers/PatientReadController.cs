using Microsoft.AspNetCore.Mvc;
using Models.DTO.UserDTO.Patient;

namespace Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> ReadPatientsAsync()
    {
        return Ok(await _patientReadRepository.ReadPatientAsync());
    }
    [HttpGet]
    public async Task<IActionResult> ReadPatientAsync([FromHeader] string Authorization)
    {
        var patientEmail = this._iTokenService.GetEmailFromJWT(Authorization);
        var patient = await _patientReadRepository.ReadPatientByEmail(patientEmail); 
        
        


        return Ok(this._mapper.Map<PatientGET>(patient));
    }
}