using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.TreatmentInterfaces;
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

        public TreatmentController
        (
            IMapper mapper,
            ITreatmentsCreate treatmentCreate,
            ITreatmentsRead treatmentsRead,
            ITreatmentsDelete treatmentsDelete,
            ITreatmentsUpdate treatmentsUpdate,
            IResponseService responseService
        )
        {
            _mapper = mapper;
            _treatmentCreate = treatmentCreate;
            _treatmentsRead = treatmentsRead;
            _treatmentsDelete = treatmentsDelete;
            _treatmentsUpdate = treatmentsUpdate;
            _responseService = responseService;
        }
    }
}