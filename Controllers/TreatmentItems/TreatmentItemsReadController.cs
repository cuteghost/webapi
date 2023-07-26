using Microsoft.AspNetCore.Mvc;
using Models.Domain;

namespace Controllers.TreatmentItemsControllers;
public partial class TreatmentItemsController : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return null;
    }
    [HttpGet]
    [Route("{id:long}")]
    public async Task<IActionResult> GetById([FromRoute]long id)
    {
        return null;
    }
}