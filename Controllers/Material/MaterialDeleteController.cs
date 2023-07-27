using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.MaterialDTO;

namespace Controllers.MaterialControllers
{
    public partial class MaterialController : Controller
    {
        [HttpPost]
        [Route("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            var exists = await _materialsDelete.DeleteMaterial(id);
            if(exists != null) return Ok("Done");
            return NotFound();
        }
    }
}