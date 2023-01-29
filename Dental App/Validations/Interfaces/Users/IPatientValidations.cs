using Dental_App.Models.DTO.UserDTO.Patient;

namespace Dental_App.Validations.Interfaces.Users;
public interface IPatientValidations
{
    public Task<bool> ValidatePOST(PatientPOST newStaff);
    public Task<bool> ValidatePATCH(PatientPATCH newStaff);
    public Task<bool> ValidateDELETE(long adminId, long userId);
}
