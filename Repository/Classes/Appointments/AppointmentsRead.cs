using Models.Domain;
using server.Database;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.AppointmentInterfaces;
using Models.DTO.AppointmentDTO;
using Services.TokenHandlerService;
using NHibernate.SqlCommand;


namespace Repository.Classes.AppointmentsRepo
{
    public class AppointmentsRead : IAppointmentsRead
    {
        private readonly DentalDBContext _dbContext;
        private readonly ITokenHandlerService _tokenHandlerService;

        public AppointmentsRead(DentalDBContext dbContext, ITokenHandlerService tokenHandlerService)
        {
            _dbContext = dbContext;
            _tokenHandlerService = tokenHandlerService;
        }
        public async Task<List<AppointmentGET>> GetAllAppointments(string token)
        {
            var patientId = _tokenHandlerService.GetPatientIdFromJWT(token);
            var staffId = _tokenHandlerService.GetStaffIdFromJWT(token);
            var query = from Appointments in _dbContext.Appointments
                                join staff in _dbContext.Staff on Appointments.Staff.StaffId equals staff.StaffId
                                join patient in _dbContext.Patients on Appointments.Patient.PatientId equals patient.PatientId
                                where patient.PatientId == patientId || staff.StaffId == staffId
                                select new {
                                    Appointments.Id,
                                    StaffName = staff.User.FirstName + " " + staff.User.LastName,
                                    PatientName = patient.User.FirstName + " " + patient.User.LastName,
                                    Appointments.Date,
                                    Appointments.AppointmentStatus
                                };
            List<AppointmentGET> appointments = new();
            foreach (var row in query)
            {
                AppointmentGET appointment = new() {
                    Id = row.Id,
                    StaffName = row.StaffName,
                    PatientName = row.PatientName,
                    Date = row.Date,
                    AppointmentStatus = row.AppointmentStatus
                };
                appointments.Add(appointment);
            }
            return await Task.FromResult(appointments);
        }

        public async Task<Appointment?> GetAppointment(long AppointmentId)
        {
            return await _dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == AppointmentId);
        }

        public async Task<bool> AppointmentExists(long appointmentId)
        {
            return await _dbContext.Appointments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == appointmentId) != null ?  true :  false;
        }
    }
}