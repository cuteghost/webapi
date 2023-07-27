using AutoMapper;
using Repository.Interfaces.CityInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CityDTO;

namespace Controllers.Users.CityController;

public partial class CityController : Controller
{
    [HttpPost]
    [Route("create")]

    public async Task<IActionResult> CreateCityAsync(CityPost newCityDTO)
    {
        var newCity = _mapper.Map<City>(newCityDTO);
        await _cityCreate.CreateCity(newCity);
        return await _responseService.Response(200, "OK");
    }
}