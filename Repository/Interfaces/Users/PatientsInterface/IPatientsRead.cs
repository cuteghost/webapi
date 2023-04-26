using Dental_App.Models.DTO.UserDTO.Patient;

namespace Dental_App.Repository.Interfaces.Users.PatientsInterface;

public interface IPatientsRead
{
    public Task<List<PatientGET>> ReadPatientAsync();
}
