using Models.Domain;
using server.Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.AppointmentInterfaces;

namespace Repository.Classes.AppointmentsRepo
{
    public class AppointmentsRead : IAppointmentsRead
    {
        private readonly DentalDBContext dbContext;

        public AppointmentsRead(DentalDBContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<List<Appointment>> GetAllAppointments()
        {
            var appointments = await dbContext.Appointments.Include(s => s.Patient).Include(s => s.Staff).AsNoTracking().ToListAsync();
            return appointments;
        }

        public async Task<Appointment?> GetAppointment(long AppointmentId)
        {
            return await dbContext.Appointments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == AppointmentId);
        }

        public async Task<bool> AppointmentExists(long appointmentId)
        {
            return await dbContext.Appointments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == appointmentId) != null ?  true :  false;
        }
    }
}