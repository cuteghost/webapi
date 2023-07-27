using AutoMapper;
using Repository.Interfaces.CountryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Services.ResponseService;
using Models.Domain;
using Models.DTO.CountryDTO;

namespace Controllers.Users.CountryController;

public partial class CountryController : Controller
{
    [HttpDelete]
    [Route("{countryId}/delete")]

    public async Task<IActionResult> DeleteCountryAsync([FromRoute] long countryId)
    {
        await _countryDelete.DeleteCountry(countryId);
        return await _responseService.Response(200, "OK");
    }
}