using AutoMapper;
using Repository.Interfaces.LocationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Controllers.Users.LocationController;
[ApiController]
[Route("/api/[controller]")]

public partial class LocationController : Controller
{
    private readonly IMapper _mapper;
    private readonly ILocationCreate _locationCreate;
    private readonly ILocationRead _locationRead;
    private readonly ILocationPatch _locationPatch;
    private readonly IResponseService _responseService;
    private readonly ILocationDelete _locationDelete;
    public LocationController(IMapper mapper, 
                              ILocationCreate locationCreate, 
                              ILocationRead locationRead, 
                              ILocationPatch locationPatch, 
                              IResponseService responseService, 
                              ILocationDelete locationDelete
                              )
    {
        _locationCreate = locationCreate;
        _locationRead = locationRead;
        _locationPatch = locationPatch;
        _locationDelete = locationDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
