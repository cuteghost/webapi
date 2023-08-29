using Repository.Interfaces.Users.PatientsInterface;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsDelete : IPatientsDelete
{
    private readonly DentalDBContext _dbContext;
    public PatientsDelete(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> DeletePatientAsync(long userId)
    {
        var patient = await _dbContext.Patients.Include(p => p.User).FirstOrDefaultAsync(patient => patient.User.Id == userId);
        if (patient != null)
        {
            patient.User.isActive = false;
            _dbContext.Update(patient);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            return 0;
        }

        return userId;

    }
}
