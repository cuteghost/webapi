using Models.Domain;

namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsRead
    {
        public Task<List<Appointment>> GetAllAppointments();
        public Task<Appointment?> GetAppointment(long AppointmentId);
        public Task<bool> AppointmentExists(long AppointmentId);
    }
}