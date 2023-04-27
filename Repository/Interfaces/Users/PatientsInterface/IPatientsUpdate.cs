using Models.Domain;

namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsUpdate
{
    public Task<long> UpdatePatientAsync(User user, Models.Domain.Patient patien);
}
