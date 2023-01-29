using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Dental_App.Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreatePatientAsync(PatientPOST newPatientDTO)
    {
        if (await _patientValidations.ValidatePOST(newPatientDTO) == true)
        {
            var userDomain = _mapper.Map<User>(newPatientDTO);
            var patientDomain = _mapper.Map<Patient>(newPatientDTO);

            await _patientCreateRepository.CreatePatientAsync(userDomain, patientDomain);

            return Ok("Patient  added successfuly!");
        }
        //return BadRequest(_staffValidations.validations.validation.validationMessage);
        return BadRequest();
    }
}