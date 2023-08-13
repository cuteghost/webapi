using Models.Domain;
using Models.DTO.AppointmentDTO;


namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsRead
    {
        public Task<List<AppointmentGET>> GetAllAppointments(string token);
        public Task<Appointment?> GetAppointment(long AppointmentId);
        public Task<bool> AppointmentExists(long AppointmentId);
    }
}