using Dental_App.Models.DTO.UserDTO.Staff;

namespace Dental_App.Validations.Interfaces.Users;
public interface IStaffValidations
{
    //public Common.Validations validations { get; set; }
    public Task<bool> ValidatePOST(StaffPost newStaff);
    public Task<bool> ValidatePATCH(StaffPatch newStaff);

    //TODO Validacija za brisanje da je admin
}
