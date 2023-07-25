using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.EducationInterfaces;
using Services.ResponseService;

namespace Controllers.Users.EducationControllers;
[ApiController]
[Route("/api/[controller]")]

public partial class EducationController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEducationsCreate _educationCreate;
    private readonly IEducationsRead _educationRead;
    private readonly IEducationsUpdate _educationUpdate;
    private readonly IResponseService _responseService;
    private readonly IEducationsDelete _educationDelete;
    public EducationController(IMapper mapper, IEducationsCreate educationCreate, IEducationsRead educationRead, IEducationsUpdate educationUpdate, IResponseService responseService, IEducationsDelete educationDelete)
    {
        _educationCreate = educationCreate;
        _educationRead = educationRead;
        _educationUpdate = educationUpdate;
        _educationDelete = educationDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
