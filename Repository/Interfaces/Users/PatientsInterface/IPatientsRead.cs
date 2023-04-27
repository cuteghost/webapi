using Models.DTO.UserDTO.Patient;

namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsRead
{
    public Task<List<PatientGET>> ReadPatientAsync();
}
