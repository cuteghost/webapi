using AutoMapper;
using Repository.Interfaces.LocationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.LocationDTO;

namespace Controllers.Users.LocationController;

public partial class LocationController : Controller
{
    [HttpPost]
    [Route("create")]

    public async Task<IActionResult> CreateLocationAsync(LocationPost newLocationDTO)
    {
        var newLocation = _mapper.Map<Location>(newLocationDTO);
        await _locationCreate.CreateLocation(newLocation);
        return await _responseService.Response(200, "OK");
    }
}