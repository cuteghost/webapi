using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.AppointmentInterfaces;
using server.Database;

namespace Repository.Classes.AppointmentsRepo
{
    public class AppointmentsDelete : IAppointmentsDelete
    {
        private readonly DentalDBContext dbContext;

        public AppointmentsDelete(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;     
        }
        public async Task<long?> DeleteAppointment(long appointmentId)
        {
            var appointment = await dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == appointmentId);
            if(appointment != null)
            {
                dbContext.Remove(appointment);
                await dbContext.SaveChangesAsync();
                return appointmentId;
            }
            return null;
        }
    }
}