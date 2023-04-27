using Models.DTO.UserDTO.Patient;
using Validations.Common.Validations;

namespace Validations.Interfaces.Users;
public interface IPatientValidations
{
    public Task<ValidationModel> ValidatePOSTRequest(PatientPOST newPatient);
    public Task<ValidationModel> ValidatePATCHRequest(PatientPATCH patient);
    public Task<ValidationModel> ValidateDELETERequest(long adminId, long userId);
}
