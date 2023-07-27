using AutoMapper;
using Repository.Interfaces.CountryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CountryDTO;

namespace Controllers.Users.CountryController;

public partial class CountryController : Controller
{
    [HttpGet]

    public async Task<IActionResult> GetAllCountries()
    {
        var countries = await _countryRead.GetAllCountries();
        return await _responseService.Response(200, countries);
    }
}