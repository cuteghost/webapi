using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Controllers.TreatmentControllers
{
    public partial class TreatmentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var treatments = await _treatmentsRead.GetAllTreatments();
            var treatmentsDto = _mapper.Map<List<TreatmentGET>>(treatments);
            return Ok(treatmentsDto);
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var treatment = await _treatmentsRead.GetTreatment(id);
            if(treatment != null) 
                return Ok(_mapper.Map<TreatmentGET>(treatment));
            return NotFound();
        }
    }
}