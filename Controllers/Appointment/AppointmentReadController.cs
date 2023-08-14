using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromHeader] string Authorization)
        {
            var appointments = await _appointmentsRead.GetAllAppointments(Authorization);
            var appointmentsDto = _mapper.Map<List<AppointmentGET>>(appointments);
            return Ok(appointmentsDto);
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var appointment = await _appointmentsRead.GetAppointment(id);
            if(appointment != null)
            {
                var appointmentGet = _mapper.Map<AppointmentGET>(appointment);
                appointmentGet.PatientName = appointment.Patient.User.FirstName + " " + appointment.Patient.User.LastName;
                appointmentGet.StaffName = appointment.Staff.User.FirstName + " " + appointment.Staff.User.LastName; 
                return Ok(appointmentGet);
            } 
            return NotFound();
        }
    }
}