using Dental_App.Models.DTO.UserDTO.Patient;
using Dental_App.Validations.Common.Validations;

namespace Dental_App.Validations.Interfaces.Users;
public interface IPatientValidations
{
    public Task<ValidationModel> ValidatePOSTRequest(PatientPOST newPatient);
    public Task<ValidationModel> ValidatePATCHRequest(PatientPATCH patient);
    public Task<ValidationModel> ValidateDELETERequest(long adminId, long userId);
}
