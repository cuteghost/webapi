using System.Security.Cryptography;
using System.Text;
using Models.Domain;
using Repository.Interfaces.Users.PatientsInterface;
using server.Database;
using Services.HashService;

namespace Repository.Classes.Users.PatientsRepo;

public class PatientsUpdate : IPatientsUpdate
{
    private readonly DentalDBContext _dbContext;
    private readonly IHashService _hasher;

    public PatientsUpdate(DentalDBContext dbContext, IHashService hasher)
    {
        this._dbContext = dbContext;
        this._hasher = hasher;
    }

    public async Task<long> UpdatePatientAsync(User user, Models.Domain.Patient patient)
    {
        try
        {
            user.Password = _hasher.Hash(user.Password);
            patient.User = user;
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
