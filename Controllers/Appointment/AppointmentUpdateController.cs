using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpPatch]
        [Route("{id:long}")]
        public async Task<IActionResult> Update(long id, AppointmentPATCH appointmentPatch)
        {
            var appointment = _mapper.Map<Appointment>(appointmentPatch); 
            var patient = await _patientRead.ReadPatientById(appointmentPatch.PatientId);
            var staff = await _staffRead.GetStaffMember(appointmentPatch.StaffId);

            appointment.Patient = _mapper.Map<Patient>(patient);
            appointment.Staff = _mapper.Map<Staff>(staff);

            var updated = await _appointmentsUpdate.UpdateAppointment(appointment, id); 
            if( updated != null)
            {
                return Ok(_mapper.Map<AppointmentGET>(appointment));
            }
            return NotFound();
        }
    }
}