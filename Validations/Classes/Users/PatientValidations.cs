using Models.DTO.UserDTO.Patient;
using Validations.Common.Validations;
using Validations.Interfaces.Users;

namespace Validations.Classes.Users;
public class PatientValidations : IPatientValidations
{
    public readonly IUserValidations _userValidations;  
	public PatientValidations(IUserValidations userValidations)
	{
		this._userValidations = userValidations;
	}
	public async Task<ValidationModel> ValidatePOSTRequest(PatientPOST newPatient)
	{
        return await _userValidations.ValidatePOSTRequest(newPatient);
    }
    public async Task<ValidationModel> ValidatePATCHRequest(PatientPATCH patient)
    {
        return await _userValidations.ValidatePATCHRequest(patient);
    }
    public async Task<ValidationModel> ValidateDELETERequest(long adminId, long userId)
    {
        return await _userValidations.ValidateDELETERequest(adminId,userId);
    }
}
