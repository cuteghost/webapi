using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.MaterialDTO;

namespace Controllers.MaterialControllers
{
    public partial class MaterialController : Controller
    {
        [HttpPatch]
        public async Task<IActionResult> Update(MaterialPATCH materialPatch)
        {
            var material = _mapper.Map<Material>(materialPatch); 
            var updated = await _materialsUpdate.UpdateMaterial(material); 
            if( updated != null)
            {
                return Ok(_mapper.Map<MaterialGET>(material));
            }
            return NotFound();
        }
    }
}