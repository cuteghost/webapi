using Dental_App.Models.Domain;
using Dental_App.Models.DTO.UserDTO;
using Dental_App.Validations.Common.Validations;

namespace Dental_App.Validations.Interfaces.Users;
public interface IUserValidations
{

    public Task<ValidationModel> ValidatePOSTRequest(UserPost newUser);
    public Task<ValidationModel> ValidatePATCHRequest(UserPatch user);
    public Task<ValidationModel> ValidatePOSTAndPATCHRequest(User user);  
    public Task<ValidationModel> ValidateDELETERequest(long adminId, long UserId);  
    public Task<bool> ValidateJMBGUnique(string jmbg, long UserId = 0);
    public Task<bool> ValidateEmailUnique(string email, long UserId = 0);
}
