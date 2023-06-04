using System.Security.Cryptography;
using System.Text;
using Models.Domain;
using Repository.Interfaces.Users.PatientsInterface;
using server.Database;
using Services.HashService;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsCreate : IPatientsCreate
{
    private readonly DentalDBContext _dbContext;
    private readonly IHashService _hasher;

    public PatientsCreate(DentalDBContext dbContext, IHashService hasher)
    {
        this._dbContext = dbContext;
        this._hasher = hasher;
    }
    public async Task<long> CreatePatientAsync(User newUser, Patient newPatient)
    {
        try
        {
            newUser.Password = _hasher.Hash(newUser.Password);
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
