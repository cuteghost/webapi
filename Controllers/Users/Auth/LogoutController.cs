using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace YourNamespace.Controllers
{
    [ApiController]
    [Route("User/Auth")]
    public class LogoutController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        [Route("Logout")] // Apply authorization to ensure only authenticated requests can access this endpoint
        public IActionResult Logout()
        {
            // Retrieve the authenticated user's token
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            // TODO: Invalidate the token (e.g., add it to a blacklist)

            return Ok();
        }
    }
}