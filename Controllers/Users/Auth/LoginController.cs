using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.Users;
using Services.TokenHandlerService;
using Services.ResponseService;
using Models.DTO.AuthDTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Controllers.Users.Auth
{
    [ApiController]
    [Route("User/Auth")]
    public class LoginController : Controller
    {
        private readonly ILoginRepo _loginRepo;
        private readonly ITokenHandlerService _tokenHandler;
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;
        public LoginController(ILoginRepo loginRepo, ITokenHandlerService tokenHandler, IResponseService responseService, IMapper mapper)
        {
            this._loginRepo = loginRepo;
            this._tokenHandler = tokenHandler;
            this._responseService = responseService;
            this._mapper = mapper;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginPOSTDTO login)
        {
            var loginDto = _mapper.Map<LoginDTO>(login);
            
            var validUser = await _loginRepo.Login(loginDto);
            if(validUser != null)
            {
                var tempUser = _mapper.Map<LoginDTO>(validUser);
                TokenDTO loginResponse = new()
                {
                    Email = loginDto.Email,
                    Token = await _tokenHandler.CreateTokenAsync(tempUser)
                };
                
                return await _responseService.Response(200,loginResponse);
            }
            else
            {
                return await _responseService.Response(401, "Unauthorized!");
            }
        }
        

        [HttpGet]
        [Route("CheckAuthentication")]
        [Authorize]
        public IActionResult CheckAuthentication()
        {
            return Ok();  // User is authenticated   
        }
    }
}