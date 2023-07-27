using Models.Domain;

namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsCreate
    {
        public Task<long> CreateAppointment(Appointment newAppointment);
    }
}