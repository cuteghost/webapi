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

            var patient = await _patientRead.ReadPatientObjectById(appointmentPost.PatientId);
            var staff = await _staffRead.GetStaffObjectMember(appointmentPost.StaffId);

            newAppointment.Patient = patient;
            newAppointment.Staff = staff;


            await _appointmentCreate.CreateAppointment(newAppointment);
            return Ok("Done");
        }
    }
}