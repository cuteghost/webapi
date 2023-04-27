using Models.DTO.UserDTO.Staff;
using Validations.Common.Validations;

namespace Validations.Interfaces.Users;
public interface IStaffValidations
{
    public Task<ValidationModel> ValidatePOSTRequest(StaffPost newStaff);
    public Task<ValidationModel> ValidatePATCHRequest(StaffPatch staff);
    public Task<ValidationModel> ValidateDELETERequest(long adminId, long userId);
    public Task<bool> ValidateStaffExists(long userId);
}
