using Models.Domain;
using Repository.Interfaces.AppointmentInterfaces;
using server.Database;

namespace Repository.Classes.AppointmentsRepo
{
    class AppointmentsCreate : IAppointmentsCreate
    {
        private readonly DentalDBContext dbContext;

        public AppointmentsCreate(DentalDBContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<long> CreateAppointment(Appointment newAppointment)
        {
            await dbContext.AddAsync(newAppointment);
            await dbContext.SaveChangesAsync();

            return newAppointment.Id;
        }
    }
}