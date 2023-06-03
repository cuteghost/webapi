using Models.Domain;
using Models.DTO.UserDTO.Patient;

namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsRead
{
    public Task<List<PatientGET>> ReadPatientAsync();
    public Task<PatientGET> ReadPatientByEmail(string email);
}
