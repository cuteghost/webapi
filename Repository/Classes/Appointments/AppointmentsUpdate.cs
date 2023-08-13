using Microsoft.EntityFrameworkCore;
using Models.Domain;
using Models.DTO.AppointmentDTO;
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

        public async Task<bool> UpdateStatus(AppointmentChangeStatus status)
        {
            var exists = await dbContext.Appointments.Include(s => s.Staff)
                                                     .Include(s => s.Patient)
                                                     .Include(s => s.Staff.User)
                                                     .Include(s => s.Patient.User).FirstOrDefaultAsync(x => x.Id == status.Id);
            if (exists != null)
            {
                exists.AppointmentStatus = status.AppointmentStatus;
                dbContext.Update(exists);
                await dbContext.SaveChangesAsync();
                return true;        
            }
            return false;
        }
    }
}