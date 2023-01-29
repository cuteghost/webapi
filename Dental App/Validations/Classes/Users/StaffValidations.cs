using Dental_App.Models.DTO.UserDTO.Staff;
using Dental_App.Validations.Common;
using Dental_App.Validations.Interfaces.Users;

namespace Dental_App.Validations.Classes.Users;
public class StaffValidations : IStaffValidations
{
    public Common.Validations validations { get; set; }
    public readonly IUserValidations userValidations;  
	public StaffValidations(IUserValidations userValidations)
	{
		this.userValidations = userValidations;
		this.validations = new Common.Validations();
	}
	public async Task<bool> ValidatePOST(StaffPost newStaff)
	{
        if (userValidations.ValidateBasics(newStaff.FirstName, newStaff.LastName, newStaff.Password, newStaff.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        if (await userValidations.ValidateJMBGUnique(jmbg:newStaff.JMBG) == false)
		{
			validations.validation = userValidations.GetValidation();
            return false;
        }

        if (await userValidations.ValidateEmailUnique(email:newStaff.Email) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
		return true;
    }
    public async Task<bool> ValidatePATCH(StaffPatch newStaff)
    {
        if(userValidations.ValidateBasics(newStaff.FirstName,newStaff.LastName,newStaff.Password,newStaff.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        if (await userValidations.ValidateJMBGUnique(jmbg: newStaff.JMBG) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }

        if (await userValidations.ValidateEmailUnique(email: newStaff.Email) == false)
        {
            validations.validation = userValidations.GetValidation();
            return false;
        }
        return true;
    }
}
