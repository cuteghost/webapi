using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Repository.Interfaces.AppointmentInterfaces;
using server.Database;

namespace Repository.Classes.AppointmentsRepo
{
    public class AppointmentsUpdate : IAppointmentsUpdate
    {
        private readonly DentalDBContext dbContext;

        public AppointmentsUpdate(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<long?> UpdateAppointment(Appointment appointment, long appointmentId)
        {
            var exists = await dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == appointmentId);
            if(exists != null)
            {
                dbContext.Update(appointment);
                await dbContext.SaveChangesAsync();
                return appointment.Id;
            }
            return null;
        }
    }
}