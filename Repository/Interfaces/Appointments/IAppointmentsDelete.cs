namespace Repository.Interfaces.AppointmentInterfaces
{
    public interface IAppointmentsDelete
    {
        public Task<long?> DeleteAppointment(long appointmentId);
    }
}