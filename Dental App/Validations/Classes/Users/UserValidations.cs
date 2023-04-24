using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO;
using Dental_App.Repository.Interfaces.Users;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using Dental_App.Validations.Common.Validations;
using Dental_App.Validations.Interfaces.Users;

namespace Dental_App.Validations.Classes.Users;
public class UserValidations : IUserValidations
{
    private readonly IValidationsService _validationsService;
    private readonly IUsersRead _usersReadRepository;
    private readonly IStaffRead _staffReadRepository;
    public UserValidations(IValidationsService validationsService,IUsersRead usersReadRepository, IStaffRead staffReadRepository)
    {
        _validationsService = validationsService;
        _usersReadRepository = usersReadRepository;
        _staffReadRepository = staffReadRepository;
    }
    public async Task<ValidationModel> ValidatePOSTRequest(UserPost newUser)
    {
        var validationResult = _validationsService.ValidateFieldsLength(newUser,new string[] {"BirthDate","Gender","Joined","Email"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(newUser.JMBG,0);
        return validationResult;
    }
    public async Task<ValidationModel> ValidatePATCHRequest(UserPatch user)
    {
        var validationResult = _validationsService.ValidateFieldsLength(user,new string[] {"Id","BirthDate","Gender","Joined","Email"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(user.JMBG,0);
        return validationResult;
    }
    public async Task<ValidationModel> ValidateDELETERequest(long adminId, long UserId)
    {
        var userAdmin = await _staffReadRepository.GetStaffUserId(adminId);
        if (userAdmin == 0)
        {
            return new ValidationModel{
                ValidationMessage="Unauthorized",
                StatusCode = 400,
                ResultOfValidations = false
            };
        }
        return new ValidationModel{
                ValidationMessage=$"User with Id: {UserId} deleted successfuly!",
                StatusCode = 201,
                ResultOfValidations = false
            };
    }
    public async Task<ValidationModel> ValidatePOSTAndPATCHRequest(User user)
    {
        var validationResult = _validationsService.ValidateFieldsLength(user,new string[] {"Id"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(user.JMBG,0);
        return validationResult;
    }
    /*
                                EXPLANATION OF methodUnique 
        parsing UserId because this method can be used with PATCH/PUT request.
        --POST:
            by default, UserId when new user is added is 0. 
            that means that if any of users had JMBG/Email/Phone that is parsed in the request, result of validation will be false
        --PUT/PATCH:
            In this types of request there is valid Id but the method GetUserByJMBG must return that Id :D 
    */
    public async Task<ValidationModel> ValidateUniqueFields(string jmbg, long UserId = 0)
    {
        if(!await ValidateJMBGUnique(jmbg,UserId)){
            return new ValidationModel{
                ValidationMessage="User with parsed JMBG already exists in the database.",
                StatusCode = 400,
                ResultOfValidations = false
            };
        }
        if(!await ValidateEmailUnique(jmbg,UserId)){
            return new ValidationModel{
                ValidationMessage="User with parsed JMBG already exists in the database.",
                StatusCode = 400,
                ResultOfValidations = false
            };
        }
        return new ValidationModel{
            ValidationMessage="OK",
            StatusCode=200,
            ResultOfValidations=true
        };
    }
    public async Task<bool> ValidateJMBGUnique(string jmbg, long UserId)
    {
        
        if (await _usersReadRepository.GetUserByJMBG(jmbg) != UserId) { return false; }
        return true;
    }
    public async Task<bool> ValidateEmailUnique(string email, long UserId)
    {
        
        if(await _usersReadRepository.GetUserByEmail(email) != 0) { return false; }
        return true;
    }
}
