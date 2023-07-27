using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.MaterialDTO;

namespace Controllers.MaterialControllers
{
    public partial class MaterialController : Controller
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(MaterialPOST materialPost)
        {
            var newMaterial = _mapper.Map<Material>(materialPost);
            await _materialCreate.CreateMaterial(newMaterial);
            return Ok("Done");
        }
    }
}