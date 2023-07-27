using Microsoft.AspNetCore.Mvc;
using Models.Domain;
using Models.DTO.AppointmentDTO;

namespace Controllers.AppointmentControllers
{
    public partial class AppointmentController : Controller
    {
        [HttpPost]
        [Route("delete/{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]long id)
        {
            var exists = await _appointmentsDelete.DeleteAppointment(id);
            if(exists != null) return Ok("Done");
            return NotFound();
        }
    }
}