using AutoMapper;
using Repository.Interfaces.LocationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.LocationDTO;

namespace Controllers.Users.LocationController;

public partial class LocationController : Controller
{
    [HttpGet]

    public async Task<IActionResult> GetAllLocations()
    {
        var locations = await _locationRead.GetAllLocations();
        return await _responseService.Response(200, locations);
    }
}