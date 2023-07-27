using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.MaterialDTO;

namespace Controllers.MaterialControllers
{
    public partial class MaterialController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var materials = await _materialsRead.GetAllMaterials();
            var materialsDto = _mapper.Map<List<MaterialGET>>(materials);
            return Ok(materialsDto);
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var material = await _materialsRead.GetMaterialById(id);
            if(material != null) 
                return Ok(_mapper.Map<MaterialGET>(material));
            return NotFound();
        }
    }
}