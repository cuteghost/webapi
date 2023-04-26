using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsCreate
{
    public Task<long> CreatePatientAsync(User newUser, Patient newPatient);
}
