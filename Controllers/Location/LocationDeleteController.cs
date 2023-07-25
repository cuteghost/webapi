using AutoMapper;
using Repository.Interfaces.LocationInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.LocationDTO;

namespace Controllers.Users.LocationController;

public partial class LocationController : Controller
{
    [HttpDelete]
    [Route("{locationId}/delete")]

    public async Task<IActionResult> DeleteLocationAsync([FromRoute] long locationId)
    {
        await _locationDelete.DeleteLocation(locationId);
        return await _responseService.Response(200, "OK");
    }
}