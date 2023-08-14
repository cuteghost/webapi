using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> Update(AppointmentPATCH appointmentPatch)
        {
            var appointment = _mapper.Map<Appointment>(appointmentPatch); 
            var patient = await _patientRead.ReadPatient(appointmentPatch.PatientId);
            var staff = await _staffRead.GetStaff(appointmentPatch.StaffId);

            appointment.Patient = _mapper.Map<Patient>(patient);
            appointment.Staff = _mapper.Map<Staff>(staff);

            var updated = await _appointmentsUpdate.UpdateAppointment(appointment);
            if( updated != null)
            {
                return Ok(_mapper.Map<AppointmentGET>(appointment));
            }
            return NotFound();
        }

        [HttpPatch]
        // [Authorize]
        [Route("change-status")]
        public async Task<IActionResult> ChangeStatus([FromBody]AppointmentChangeStatus status)
        {
            var updatedStatus = await _appointmentsUpdate.UpdateStatus(status);
            if(updatedStatus != false)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}