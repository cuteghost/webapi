using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Controllers.TreatmentControllers
{
    public partial class TreatmentController : Controller
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(TreatmentPOST treatmentPost)
        {
            var newTreatment = _mapper.Map<Treatment>(treatmentPost);
            
            var staffMemberDto = await _staffRead.GetStaffMember(treatmentPost.StaffId);
            newTreatment.Staff = _mapper.Map<Staff>(staffMemberDto);
           
            var patientDto = await _patientRead.ReadPatientById(treatmentPost.StaffId);
            newTreatment.Patient = _mapper.Map<Patient>(patientDto);
            
            await _treatmentCreate.CreateTreatment(newTreatment);
            return Ok("Done");
        }
    }
}