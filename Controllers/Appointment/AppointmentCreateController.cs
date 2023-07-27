using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAsync(AppointmentPOST appointmentPost)
        {
            var newAppointment = _mapper.Map<Appointment>(appointmentPost);

            var patient = await _patientRead.ReadPatientById(appointmentPost.PatientId);
            var staff = await _staffRead.GetStaffMember(appointmentPost.StaffId);

            newAppointment.Patient = _mapper.Map<Patient>(patient);
            newAppointment.Staff = _mapper.Map<Staff>(staff);
            
            await _appointmentCreate.CreateAppointment(newAppointment);
            return Ok("Done");
        }
    }
}