using AutoMapper;
using Repository.Interfaces.LocationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.LocationDTO;

namespace Controllers.Users.LocationController;

public partial class LocationController : Controller
{
    [HttpPatch]
    [Route("patch")]

    public async Task<IActionResult> PatchLocationAsync([FromBody] LocationPatch location)
    {
        var newLocation = _mapper.Map<Location>(location);
        await _locationPatch.PatchLocation(newLocation);
        return await _responseService.Response(200, "OK");
    }
}