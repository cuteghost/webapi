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
            var appointment = await _appointmentRead.GetAppointment(treatmentPost.AppointmentId);
            newTreatment.Appointment = appointment;            
            await _treatmentCreate.CreateTreatment(newTreatment);
            return Ok("Done");
        }
    }
}