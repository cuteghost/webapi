namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsDelete
{
    public Task<long> DeletePatientAsync(long userId);
}
