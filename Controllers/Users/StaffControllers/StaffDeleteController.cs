using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.StaffControllers;
public partial class StaffController : Controller
{
    [HttpDelete]
    [Route("delete/{adminId}/{userId}")]
    public async Task<IActionResult> DeleteStaffMember(long adminId, long userId)
    {
        var validationResult = await _staffValidations.ValidateDELETERequest(adminId,userId); 
        if(validationResult.ResultOfValidations == false) { return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);}
        await _staffDeleteRepository.DeleteUser(userId);
        return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
    }
}