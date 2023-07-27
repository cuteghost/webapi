using AutoMapper;
using Repository.Interfaces.CountryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CountryDTO;

namespace Controllers.Users.CountryController;

public partial class CountryController : Controller
{
    [HttpPost]
    [Route("create")]

    public async Task<IActionResult> CreateCountryAsync(CountryPost newCountryDTO)
    {
        var newCountry = _mapper.Map<Country>(newCountryDTO);
        await _countryCreate.CreateCountry(newCountry);
        return await _responseService.Response(200, "OK");
    }
}