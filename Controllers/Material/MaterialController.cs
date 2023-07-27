using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces.MaterialInterfaces;
using Repository.Interfaces.Users.PatientsInterface;
using Repository.Interfaces.Users.StaffInterfaces;
using Services.ResponseService;

namespace Controllers.MaterialControllers
{
    [ApiController]
    [Route("/api/[controller]")] 
    public partial class MaterialController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMaterialsCreate _materialCreate;
        private readonly IMaterialsRead _materialsRead;
        private readonly IMaterialsDelete _materialsDelete;
        private readonly IMaterialsUpdate _materialsUpdate;
        private readonly IResponseService _responseService;

        public MaterialController
        (
            IMapper mapper,
            IMaterialsCreate materialCreate,
            IMaterialsRead materialsRead,
            IMaterialsDelete materialsDelete,
            IMaterialsUpdate materialsUpdate,
            IResponseService responseService
        )
        {
            _mapper = mapper;
            _materialCreate = materialCreate;
            _materialsRead = materialsRead;
            _materialsDelete = materialsDelete;
            _materialsUpdate = materialsUpdate;
            _responseService = responseService;
        }
    }
}