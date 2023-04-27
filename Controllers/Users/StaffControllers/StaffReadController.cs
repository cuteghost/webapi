using Microsoft.AspNetCore.Mvc;

namespace Controllers.Users.StaffControllers;
public partial class StaffController : Controller
{
    [HttpGet]
    [Route("get-by-id/{userId}")]
    public async Task<IActionResult> GetStaffMemberAsync(long userId)
    {
        var staffMemberDTO = await _staffReadRepository.GetStaffMember(userId);
        return await _responseService.Response(200,staffMemberDTO);
    }
    [HttpGet]
    [Route("get-all")]
    public async Task<IActionResult> GetStaffTeamAsync()
    {
        var staffMemberDTO = await _staffReadRepository.GetStaffTeam();
        return await _responseService.Response(200,staffMemberDTO);
    }
}