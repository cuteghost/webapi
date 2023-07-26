using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.TreatmentInterfaces;
using Repository.Interfaces.TreatmentItems;
using Services.ResponseService;

namespace Controllers.TreatmentItemsControllers
{
    [ApiController]
    [Route("/api/[controller]")] 
    public partial class TreatmentItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITreatmentItemsCreate _treatmentItemsCreate;

        private readonly ITreatmentsRead _treatmentsRead;
        /* nije implementirano
        private readonly ITreatmentItemsRead _treatmentItemsRead;
        private readonly ITreatmentItemsDelete _treatmentItemsDelete;
        private readonly ITreatmentItemsUpdate _treatmentItemsUpdate;
        */
        private readonly IResponseService _responseService;

        public TreatmentItemsController
        (
            IMapper mapper,
            ITreatmentItemsCreate treatmentItemsCreate,
            ITreatmentsRead treatmentsRead,
            //ITreatmentsRead treatmentsRead,
            //ITreatmentsDelete treatmentsDelete,
            //ITreatmentsUpdate treatmentsUpdate,
            IResponseService responseService
        )
        {
            _mapper = mapper;
            _treatmentItemsCreate = treatmentItemsCreate;
            _treatmentsRead = treatmentsRead;
            /* Nije implementirano */
            //_treatmentItemsRead = treatmentItemsRead;
            //_treatmentItemsDelete = treatmentItemsDelete;
            //_treatmentItemsUpdate = treatmentItemsUpdate;
            _responseService = responseService;
        }
    }
}