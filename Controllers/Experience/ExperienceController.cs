using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.ExperienceInterfaces;
using Services.ResponseService;

namespace Controllers.Users.ExperienceControllers;
[ApiController]
[Route("/api/[controller]")]

public partial class ExperienceController : Controller
{
    private readonly IMapper _mapper;
    private readonly IExperiencesCreate _experienceCreate;
    private readonly IExperiencesRead _experienceRead;
    private readonly IExperiencesUpdate _experienceUpdate;
    private readonly IResponseService _responseService;
    private readonly IExperiencesDelete _experienceDelete;
    public ExperienceController(IMapper mapper, 
                                IExperiencesCreate experienceCreate, 
                                IExperiencesRead experienceRead, 
                                IExperiencesUpdate experienceUpdate, 
                                IResponseService responseService, 
                                IExperiencesDelete experienceDelete)
    {
        _experienceCreate = experienceCreate;
        _experienceRead = experienceRead;
        _experienceUpdate = experienceUpdate;
        _experienceDelete = experienceDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
