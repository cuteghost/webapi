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
        return await _responseService.Response(200, cities);
    }
}