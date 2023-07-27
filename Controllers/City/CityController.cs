using AutoMapper;
using Repository.Interfaces.CityInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Controllers.Users.CityController;
[ApiController]
[Route("/api/[controller]")]

public partial class CityController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICityCreate _cityCreate;
    private readonly ICityRead _cityRead;
    private readonly ICityPatch _cityPatch;
    private readonly IResponseService _responseService;
    private readonly ICityDelete _cityDelete;
    public CityController(IMapper mapper, 
                              ICityCreate cityCreate, 
                              ICityRead cityRead, 
                              ICityPatch cityPatch, 
                              IResponseService responseService, 
                              ICityDelete cityDelete
                              )
    {
        _cityCreate = cityCreate;
        _cityRead = cityRead;
        _cityPatch = cityPatch;
        _cityDelete = cityDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
