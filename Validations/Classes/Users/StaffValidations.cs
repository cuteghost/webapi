using Models.DTO.UserDTO.Staff;
using Repository.Interfaces.Users.StaffInterfaces;
using Validations.Common.Validations;
using Validations.Interfaces.Users;

namespace Validations.Classes.Users;
public class StaffValidations : IStaffValidations
{
    public readonly IStaffRead _staffReadRepository;
    public readonly IUserValidations _userValidations;  
	public StaffValidations(IUserValidations userValidations, IStaffRead staffReadRepository)
	{
		this._userValidations = userValidations;
        _staffReadRepository = staffReadRepository;
	}
	public async Task<ValidationModel> ValidatePOSTRequest(StaffPost newStaff)
	{
        return await _userValidations.ValidatePOSTRequest(newStaff);
    }
    public async Task<ValidationModel> ValidatePATCHRequest(StaffPatch staff)
    {
        if(!await ValidateStaffExists(staff.Id))
        {
            return new ValidationModel
            {
                ValidationMessage="Staff member which you want to edit doesn't exists in database!",
                StatusCode=400,
                ResultOfValidations=false
            };
        }
        return await _userValidations.ValidatePATCHRequest(staff);
    }
    public async Task<ValidationModel> ValidateDELETERequest(long adminId, long userId)
    {
        return await _userValidations.ValidateDELETERequest(adminId,userId);
    }
     public async Task<bool> ValidateStaffExists(long userId){
        if(await _staffReadRepository.GetStaffUserId(userId) == 0){ return false; }
        return true;
    }
}
