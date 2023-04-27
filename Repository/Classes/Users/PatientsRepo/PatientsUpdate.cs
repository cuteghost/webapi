using Models.Domain;
using Repository.Interfaces.Users.PatientsInterface;
using server.Database;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsUpdate : IPatientsUpdate
{
    private readonly DentalDBContext _dbContext;

    public PatientsUpdate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<long> UpdatePatientAsync(User user, Models.Domain.Patient patient)
    {
        try
        {
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();

            _dbContext.Update(patient);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
