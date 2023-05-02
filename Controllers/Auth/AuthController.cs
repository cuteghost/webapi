using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Models.DTO.Auth;

namespace Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        // POST; /api/auth/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            
            if(identityResult.Succeeded)
            {   
                if(registerRequestDto.Roles != null)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("Success registration");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if(user != null)
            {
                var passwordCheck = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if(passwordCheck == true)
                {
                    // Create Token
                    return Ok("Success");
                }
            }
            return BadRequest("Check Username or Password");
             
        }
    }

}