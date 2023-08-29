using AutoMapper;
using Repository.Interfaces.CityInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CityDTO;

namespace Controllers.Users.CityController;

public partial class CityController : Controller
{
    [HttpGet]

    public async Task<IActionResult> GetAllCities()
    {
        var cities = await _cityRead.GetAllCities();
        var mappedCities = _mapper.Map<List<CityGET>>(cities);
        return Ok(mappedCities);
    }
}