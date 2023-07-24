using AutoMapper;
using Models.Domain;
using Models.DTO.UserDTO.Staff;
using Repository.Interfaces.Users.StaffInterfaces;
using Validations.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Microsoft.AspNetCore.Authorization;
using Services.TokenHandlerService;

namespace Controllers.Users.StaffControllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public partial class StaffController : Controller
{
    private readonly IStaffCreate _staffCreateRepository;
    private readonly IStaffRead _staffReadRepository;
    private readonly IStaffUpdate _staffUpdateRepository;
    private readonly IStaffDelete _staffDeleteRepository;

    private readonly IResponseService _responseService;
    private readonly IStaffValidations _staffValidations;
    private readonly IMapper _mapper;
    private readonly ITokenHandlerService _iTokenService;

    public StaffController(IStaffCreate staffCreateRepository, 
                           IStaffRead staffReadRepository, 
                           IStaffUpdate staffUpdateRepository, 
                           IStaffDelete staffDeleteRepository, 
                           IStaffValidations staffValidations,
                           IResponseService responseService, 
                           IMapper mapper,
                           ITokenHandlerService iTokenService)
    {
        _staffCreateRepository = staffCreateRepository;
        _staffReadRepository = staffReadRepository;
        _staffUpdateRepository = staffUpdateRepository;
        _staffDeleteRepository = staffDeleteRepository;
        _staffValidations = staffValidations;
        _responseService = responseService;
        _mapper = mapper;
        _iTokenService = iTokenService;

    }
}
