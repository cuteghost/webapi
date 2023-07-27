using AutoMapper;
using Repository.Interfaces.CountryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CountryDTO;

namespace Controllers.Users.CountryController;

public partial class CountryController : Controller
{
    [HttpPatch]
    [Route("patch")]

    public async Task<IActionResult> PatchCountryAsync([FromBody] CountryPATCH country)
    {
        var newCountry = _mapper.Map<Country>(country);
        await _countryPatch.PatchCountry(newCountry);
        return await _responseService.Response(200, "OK");
    }
}