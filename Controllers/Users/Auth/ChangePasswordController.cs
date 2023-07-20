using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.AuthDTO;
using Repository.Interfaces.Users;
using Services.ResponseService;
using Services.TokenHandlerService;

namespace Controllers.Users
{
    [ApiController]
    [Route("User/Auth")]
    public class ChangePasswordController : Controller
    {
        private readonly ITokenHandlerService _tokenHandler;
        private readonly IResponseService _responseService;
        private readonly IChangePassword _changePassword;

        public ChangePasswordController(ITokenHandlerService tokenHandler, IResponseService responseService, IChangePassword changePassword)
        {
            this._tokenHandler = tokenHandler;
            this._responseService = responseService;
            this._changePassword = changePassword;
        }
        
        [Authorize]
        [HttpPatch]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO newPassword, [FromHeader] string Authorization)
        {
            var email = _tokenHandler.GetEmailFromJWT(Authorization);
            if(await _changePassword.ChangePasswordAsync(newPassword, email) == true)
            {
                return await _responseService.Response(200, "Changed Successfully");
            }
            else
            {
                return await _responseService.Response(400, "Wrong password");
            }
        }
    }
}