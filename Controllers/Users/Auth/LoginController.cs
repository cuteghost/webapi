using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.Users;
using Services.TokenHandlerService;
using Services.ResponseService;
using Models.DTO.AuthDTO;
using AutoMapper;

namespace Controllers.Users.Auth
{
    [ApiController]
    [Route("User/Auth/Login")]
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
        public async Task<IActionResult> LoginAsync(LoginDTO user)
        {
            var validUser = await _loginRepo.Login(user);
            if(validUser != null)
            {
                var tempUser = _mapper.Map<LoginDTO>(validUser);
                TokenDTO loginResponse = new()
                {
                    Email = user.Email,
                    Token = await _tokenHandler.CreateTokenAsync(tempUser)
                };
                
                return await _responseService.Response(200,loginResponse);
            }
            else
            {
                return await _responseService.Response(401, "Unauthorized!");
            }
        }

    }
}