using AutoMapper;
using Repository.Interfaces.CityInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CityDTO;

namespace Controllers.Users.CityController;

public partial class CityController : Controller
{
    [HttpPatch]
    [Route("patch")]

    public async Task<IActionResult> PatchCityAsync([FromBody] CityPATCH city)
    {
        var newCity = _mapper.Map<City>(city);
        await _cityPatch.PatchCity(newCity);
        return await _responseService.Response(200, "OK");
    }
}