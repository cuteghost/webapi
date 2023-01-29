using Dental_App.Validations.Common;
using Dental_App.Validations.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Dental_App.Validations.Classes.Users;
public class UserValidations : IUserValidations
{
	private readonly DentalDBContext _dbContext;
    public readonly Common.Validations validations;
	public UserValidations(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
        this.validations = new Common.Validations();
    }
	public bool ValidateBasics(string firstName, string lastName, string password,string jmbg)
	{
        if (validations.ValidateLength(field: firstName, minLength: 3, maxLength: 15) == false)
        {
            return false;
        }
        if (validations.ValidateLength(field: lastName, minLength: 3, maxLength: 30) == false)
        {
            return false;
        }
        if (validations.ValidateLength(field: password, minLength: 8, maxLength: 16) == false)
        {
            return false;
        }
        if (validations.ValidateLength(field: jmbg, minLength: 13, maxLength: 13) == false)
        {
            return false;
        }
        return true;
    }
    public async Task<bool> ValidateJMBGUnique(string jmbg, long UserId = 0)
	{
		if(await _dbContext.Users.AsNoTracking().Where(user=>(user.JMBG == jmbg && UserId == 0) || (user.Id != UserId && user.JMBG == jmbg) ).Select(user=>user.Id).FirstOrDefaultAsync() != 0)
		{
			validations.validation.statusCode = 400;
            validations.validation.validationMessage = String.Format("User with JMBG: '{0}' already exists in database!", jmbg);
			return false;
		}
		return true;
	}
    public async Task<bool> ValidateEmailUnique(string email, long UserId = 0)
	{
        if (await _dbContext.Users.AsNoTracking().Where(user => (user.Email == email && UserId == 0) || (user.Id != UserId && user.Email == email)).Select(user => user.Id).FirstOrDefaultAsync() != 0)
        {
            validations.validation.statusCode = 400;
            validations.validation.validationMessage = String.Format("User with e-mail: '{0}' already exists in database!", email);
            return false;
        }
        return true;
    }
	public Validation GetValidation()
	{
		return validations.validation;
	}
}
