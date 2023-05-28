using System.Security.Cryptography;
using System.Text;
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
            newUser.Password = HashPassword(newUser.Password);
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
