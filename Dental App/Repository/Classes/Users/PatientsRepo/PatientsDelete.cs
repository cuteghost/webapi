using Dental_App.Repository.Interfaces.Users.PatientsInterface;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Dental_App.Repository.Classes.Users.PatientsRepo;

public class PatientsDelete : IPatientsDelete
{
    private readonly DentalDBContext _dbContext;
    public PatientsDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeletePatientAsync(long adminId, long userId)
    {
        var patient = await _dbContext.Patients.FirstOrDefaultAsync(patient => patient.PatientId == userId);
        if (patient != null)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == patient.User.Id);
            if (user != null)
            {
                _dbContext.Remove(user);
                _dbContext.Remove(patient);
            }
            else
            {
                return 0;
            }
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            return 0;
        }

        return userId;

    }
}
