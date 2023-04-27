using Models.Domain;
using Repository.Interfaces.Users.PatientsInterface;
using server.Database;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsCreate : IPatientsCreate
{
    private readonly DentalDBContext _dbContext;
    public PatientsCreate(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<long> CreatePatientAsync(User newUser, Patient newPatient)
    {
        try
        {
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            newPatient.User = newUser;

            await _dbContext.Patients.AddAsync(newPatient);
            await _dbContext.SaveChangesAsync();

            return newUser.Id;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
