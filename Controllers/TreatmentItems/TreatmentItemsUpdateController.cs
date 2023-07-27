using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentItemsDTO;

namespace Controllers.TreatmentItemsControllers;
public partial class TreatmentItemsController : Controller
{
    [HttpPatch]
    [Route("{id:long}")]
    public async Task<IActionResult> Update(long id, TreatmentItemsPATCH treatmentPatch)
    {
        return null;
    }
}