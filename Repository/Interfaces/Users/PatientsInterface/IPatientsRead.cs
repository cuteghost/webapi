using Models.Domain;
using Models.DTO.UserDTO.Patient;

namespace Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsRead
{
    public Task<List<PatientGET>> ReadPatientsAsync();
    public Task<PatientGET> ReadPatientByEmail(string email);
    public Task<PatientGET> ReadPatientById(long patientId);
    public Task<Patient> ReadPatientObjectById(long patientId);
    public Task<Patient> ReadPatientByEmail(string email, string _="");

}
