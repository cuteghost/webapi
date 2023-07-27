using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _appointmentsRead.GetAllAppointments();
            var appointmentsDto = _mapper.Map<List<AppointmentGET>>(appointments);
            return Ok(appointmentsDto);
        }
        [HttpGet]
        [Route("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var appointment = await _appointmentsRead.GetAppointment(id);
            if(appointment != null) 
                return Ok(_mapper.Map<AppointmentGET>(appointment));
            return NotFound();
        }
    }
}