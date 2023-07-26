using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Controllers.TreatmentItemsControllers
{
    public partial class TreatmentItemsController : Controller
    {
        [HttpPost]
        [Route("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            return null;
        }
    }
}