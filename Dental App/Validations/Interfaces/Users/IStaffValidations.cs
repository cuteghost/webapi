using Dental_App.Models.DTO.UserDTO.Staff;
using Dental_App.Validations.Common.Validations;

namespace Dental_App.Validations.Interfaces.Users;
public interface IStaffValidations
{
    public Task<ValidationModel> ValidatePOSTRequest(StaffPost newStaff);
    public Task<ValidationModel> ValidatePATCHRequest(StaffPatch staff);
    public Task<ValidationModel> ValidateDELETERequest(long adminId, long userId);
}
