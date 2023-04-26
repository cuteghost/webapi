using Dental_App.Models.DTO.UserDTO.Staff;
using Dental_App.Validations.Common.Validations;
using Dental_App.Validations.Interfaces.Users;

namespace Dental_App.Validations.Classes.Users;
public class StaffValidations : IStaffValidations
{
    public readonly IUserValidations _userValidations;  
	public StaffValidations(IUserValidations userValidations)
	{
		this._userValidations = userValidations;
	}
	public async Task<ValidationModel> ValidatePOSTRequest(StaffPost newStaff)
	{
        return await _userValidations.ValidatePOSTRequest(newStaff);
    }
    public async Task<ValidationModel> ValidatePATCHRequest(StaffPatch staff)
    {
        return await _userValidations.ValidatePATCHRequest(staff);
    }
    public async Task<ValidationModel> ValidateDELETERequest(long adminId, long userId)
    {
        return await _userValidations.ValidateDELETERequest(adminId,userId);
    }
}
