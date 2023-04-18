using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpGet]
    public async Task<IActionResult> ReadPatientsAsync()
    {
        return Ok(await _patientReadRepository.ReadPatientAsync());
    }
}