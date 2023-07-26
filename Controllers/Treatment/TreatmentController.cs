using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.TreatmentInterfaces;
using Repository.Interfaces.Users.PatientsInterface;
using Repository.Interfaces.Users.StaffInterfaces;
using Services.ResponseService;

namespace Controllers.TreatmentControllers
{
    [ApiController]
    [Route("/api/[controller]")] 
    public partial class TreatmentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITreatmentsCreate _treatmentCreate;
        private readonly ITreatmentsRead _treatmentsRead;
        private readonly ITreatmentsDelete _treatmentsDelete;
        private readonly ITreatmentsUpdate _treatmentsUpdate;
        private readonly IResponseService _responseService;

        private readonly IStaffRead _staffRead;
        private readonly IPatientsRead _patientRead;

        public TreatmentController
        (
            IMapper mapper,
            ITreatmentsCreate treatmentCreate,
            ITreatmentsRead treatmentsRead,
            ITreatmentsDelete treatmentsDelete,
            ITreatmentsUpdate treatmentsUpdate,
            IResponseService responseService,
            IStaffRead staffRead,
            IPatientsRead patientRead
        )
        {
            _mapper = mapper;
            _treatmentCreate = treatmentCreate;
            _treatmentsRead = treatmentsRead;
            _treatmentsDelete = treatmentsDelete;
            _treatmentsUpdate = treatmentsUpdate;
            _responseService = responseService;
            _staffRead = staffRead;
            _patientRead = patientRead;
        }
    }
}