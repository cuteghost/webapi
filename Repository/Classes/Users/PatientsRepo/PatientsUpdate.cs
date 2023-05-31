using System.Security.Cryptography;
using System.Text;
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
            user.Password = HashPassword(user.Password);
            //_dbContext.Update(user);
            //await _dbContext.SaveChangesAsync();
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


    public string HashPassword(string password)
    {
        StringBuilder Sb = new StringBuilder();


        using (SHA256 hash = SHA256Managed.Create()) {

            Encoding enc = Encoding.UTF8;

            Byte[] result = hash.ComputeHash(enc.GetBytes(password));


            foreach (Byte b in result)

            Sb.Append(b.ToString("x2"));

        }
        return Sb.ToString();   
    }
}
