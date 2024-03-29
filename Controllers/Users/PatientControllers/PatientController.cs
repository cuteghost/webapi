﻿using AutoMapper;
using Repository.Interfaces.Users.PatientsInterface;
using Validations.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Microsoft.AspNetCore.Authorization;
using Services.TokenHandlerService;

namespace Controllers.Users.PatientControllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]

public partial class PatientController : Controller
{
    private readonly IPatientsCreate _patientCreateRepository;
    private readonly IPatientsRead _patientReadRepository;
    private readonly IPatientsUpdate _patientUpdateRepository;
    private readonly IPatientsDelete _patientDeleteRepository;
    private readonly IResponseService _responseService;
    private readonly IPatientValidations _patientValidations;
    private readonly IMapper _mapper;
    private readonly ITokenHandlerService _iTokenService;

    public PatientController(IPatientsCreate patientCreateRepository, IPatientsRead patientReadRepository,IPatientsUpdate patientUpdateRepository, 
                            IPatientsDelete patientDeleteRepository, IPatientValidations patientValidations,IResponseService responseService,IMapper mapper, ITokenHandlerService tokenService)
    {
        _patientCreateRepository = patientCreateRepository;
        _patientReadRepository = patientReadRepository;
        _patientUpdateRepository = patientUpdateRepository;
        _patientDeleteRepository = patientDeleteRepository;
        _patientValidations = patientValidations;
        _responseService = responseService;
        _iTokenService = tokenService;
        _mapper = mapper;
    }
}
