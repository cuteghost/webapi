using AutoMapper;
using Repository.Interfaces.CityInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CityDTO;

namespace Controllers.Users.CityController;

public partial class CityController : Controller
{
    [HttpDelete]
    [Route("{cityId}/delete")]

    public async Task<IActionResult> DeleteCityAsync([FromRoute] long cityId)
    {
        await _cityDelete.DeleteCity(cityId);
        return await _responseService.Response(200, "OK");
    }
}