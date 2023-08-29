using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.TreatmentDTO;

namespace Controllers.TreatmentControllers
{
    public partial class TreatmentController : Controller
    {
        [HttpPatch]
        [Route("{id:long}")]
        public async Task<IActionResult> Update(long id, TreatmentPATCH treatmentPatch)
        {
            var treatment = _mapper.Map<Treatment>(treatmentPatch);
            var appointment = await _appointmentRead.GetAppointment(treatmentPatch.AppointmentId);
            treatment.Appointment = appointment;    
            var updated = await _treatmentsUpdate.UpdateTreatment(treatment, id); 
            if( updated != null)
            {
                return Ok(_mapper.Map<TreatmentGET>(treatment));
            }
            return NotFound();
        }
        [HttpPatch]
        [Route("invoice/{id:long}")]
        public async Task<IActionResult> UpdateTreatmentInvoice(long id, TreatmentInvoicePATCH invoiceData)
        {
            var updated = await _treatmentsUpdate.UpdateTreatmentInvoice(id, invoiceData.InvoiceId);
            if( updated != -1)
            {
                return Ok(id);
            }
            else
            {
                return NotFound();
            }
        }
    }

}