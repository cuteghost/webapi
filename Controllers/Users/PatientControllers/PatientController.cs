using AutoMapper;
using Dental_App.Repository.Interfaces.Users.PatientsInterface;
using Dental_App.Validations.Interfaces.Users;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Dental_App.Controllers.Users.PatientControllers;

[ApiController]
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

    public PatientController(IPatientsCreate patientCreateRepository, IPatientsRead patientReadRepository,IPatientsUpdate patientUpdateRepository, 
                            IPatientsDelete patientDeleteRepository, IPatientValidations patientValidations,IResponseService responseService,IMapper mapper)
    {
        _patientCreateRepository = patientCreateRepository;
        _patientReadRepository = patientReadRepository;
        _patientUpdateRepository = patientUpdateRepository;
        _patientDeleteRepository = patientDeleteRepository;
        _patientValidations = patientValidations;
        _responseService = responseService;
        _mapper = mapper;
    }
}
