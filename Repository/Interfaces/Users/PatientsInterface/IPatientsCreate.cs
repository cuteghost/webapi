using Models.Domain;

namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsCreate
{
    public Task<long> CreatePatientAsync(User newUser, Patient newPatient);
    public string HashPassword(string passsword);
}
