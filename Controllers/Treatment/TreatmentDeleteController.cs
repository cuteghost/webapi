using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Controllers.TreatmentControllers
{
    public partial class TreatmentController : Controller
    {
        [HttpPost]
        [Route("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            var exists = await _treatmentsDelete.DeleteTreatment(id);
            if(exists != null) return Ok("Done");
            return NotFound();
        }
    }
}