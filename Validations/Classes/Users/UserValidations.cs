﻿﻿using Models.Domain;
using Models.DTO.UserDTO;
using Repository.Interfaces.Users;
using Repository.Interfaces.Users.StaffInterfaces;
using Validations.Common.Validations;
using Validations.Interfaces.Users;

namespace Validations.Classes.Users;
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
        var validationResult = _validationsService.ValidateFieldsLength(newUser,new string[] {"UserId","BirthDate","Gender","Joined","Email","FirstVisitDate","LastVisitDate","LastPaymentDate"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(newUser.Email, newUser.JMBG, 0);
        return validationResult;
    }
    public async Task<ValidationModel> ValidatePATCHRequest(UserPatch user)
    {
        var validationResult = _validationsService.ValidateFieldsLength(user,new string[] {"Id", "PatientId", "StaffId","BirthDate","Gender","Joined","Email","FirstVisitDate","LastVisitDate","LastPaymentDate", "Telephone","Address"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(user.Email, user.JMBG, user.Id);
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
                ResultOfValidations = true
            };
    }
    public async Task<ValidationModel> ValidatePOSTAndPATCHRequest(User user)
    {
        var validationResult = _validationsService.ValidateFieldsLength(user,new string[] {"Id", "PatientId"},("",""));
        if(!validationResult.ResultOfValidations) return validationResult;
        validationResult = await ValidateUniqueFields(user.Email,user.JMBG,0);
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
    public async Task<ValidationModel> ValidateUniqueFields(string email, string jmbg, long UserId = 0)
    {
        if(!await ValidateJMBGUnique(jmbg,UserId)){
            return new ValidationModel{
                ValidationMessage="User with parsed JMBG already exists in the database.",
                StatusCode = 400,
                ResultOfValidations = false
            };
        }
        if(!await ValidateEmailUnique(email,UserId)){
            return new ValidationModel{
                ValidationMessage="User with Email already exists in the database.",
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
        var id = await _usersReadRepository.GetUserByJMBG(jmbg);
        if (id != UserId && id != 0) { return false; }
        return true;
    }
    public async Task<bool> ValidateEmailUnique(string email, long UserId)
    {
        var id = await _usersReadRepository.GetUserByEmail(email);
        if(id != UserId && id != 0) { return false; }
        return true;
    }
}