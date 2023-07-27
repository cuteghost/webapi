using AutoMapper;
using Repository.Interfaces.CountryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;

namespace Controllers.Users.CountryController;
[ApiController]
[Route("/api/[controller]")]

public partial class CountryController : Controller
{
    private readonly IMapper _mapper;
    private readonly ICountryCreate _countryCreate;
    private readonly ICountryRead _countryRead;
    private readonly ICountryPatch _countryPatch;
    private readonly IResponseService _responseService;
    private readonly ICountryDelete _countryDelete;
    public CountryController(IMapper mapper, 
                              ICountryCreate countryCreate, 
                              ICountryRead countryRead, 
                              ICountryPatch countryPatch, 
                              IResponseService responseService, 
                              ICountryDelete countryDelete
                              )
    {
        _countryCreate = countryCreate;
        _countryRead = countryRead;
        _countryPatch = countryPatch;
        _countryDelete = countryDelete;
        _mapper = mapper;
        _responseService = responseService;
    }
}
