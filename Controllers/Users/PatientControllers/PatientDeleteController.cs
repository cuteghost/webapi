using Models.Domain;
using Models.DTO.UserDTO.Patient;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.PatientControllers;
public partial class PatientController : Controller
{
    [HttpDelete]
    [Route("delete/{AdminId}/{UserId}")]
    public async Task<IActionResult> DeletePatientAsync(long adminId, long userId)
    {
        var validationResult = await _patientValidations.ValidateDELETERequest(adminId,userId);
        if (validationResult.ResultOfValidations == true)
        {
            await _patientDeleteRepository.DeletePatientAsync(adminId, userId);
        }
         return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}