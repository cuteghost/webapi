using Models.Domain;

namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsUpdate
    {
        public Task<long?> UpdateAppointment(Appointment appointment, long appointmetnId);
    }
}