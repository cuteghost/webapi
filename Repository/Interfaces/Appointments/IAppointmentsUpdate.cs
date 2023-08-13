using Models.Domain;
using Models.DTO.AppointmentDTO;


namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsUpdate
    {
        public Task<long?> UpdateAppointment(Appointment appointment, long appointmetnId);
        public Task<bool> UpdateStatus(AppointmentChangeStatus status);
    }
}