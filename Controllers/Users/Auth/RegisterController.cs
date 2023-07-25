using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using AutoMapper;
using Models.DTO.UserDTO.Patient;
using Repository.Interfaces.Users.PatientsInterface;
using Validations.Interfaces.Users;
using Models.Domain;

namespace Controllers.Users.Auth
{
    [ApiController]
    [Route("User/Auth/Register")]
    public class RegisterController : Controller
    {
        private readonly IPatientsCreate _patientCreateRepository;
        private readonly IResponseService _responseService;
        private readonly IPatientValidations _patientValidations;
        private readonly IMapper _mapper;

        public RegisterController(IPatientsCreate patientCreateRepository, IPatientValidations patientValidations,IResponseService responseService,IMapper mapper)
        {
            _patientCreateRepository = patientCreateRepository;
            _patientValidations = patientValidations;
            _responseService = responseService;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("patient")]
        public async Task<IActionResult> RegisterPatientAsync(PatientPOST newPatientDTO)
        {
            var validationResult = await _patientValidations.ValidatePOSTRequest(newPatientDTO);
            if (validationResult.ResultOfValidations == true)
            {
                var userDomain = _mapper.Map<User>(newPatientDTO);
                var patientDomain = _mapper.Map<Patient>(newPatientDTO);
                await _patientCreateRepository.CreatePatientAsync(userDomain, patientDomain);                
            }
            return await _responseService.Response(validationResult.StatusCode,validationResult.ValidationMessage);
        }
    }
}