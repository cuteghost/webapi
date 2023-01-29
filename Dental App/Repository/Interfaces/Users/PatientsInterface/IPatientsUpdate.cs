using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsUpdate
{
    public Task<long> UpdatePatientAsync(User user, Dental_App.Models.Domain.Patient patien);
}
