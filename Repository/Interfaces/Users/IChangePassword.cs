using Models.DTO.AuthDTO;

namespace Repository.Interfaces.Users;
public interface IChangePassword
{
    public Task<bool> ChangePasswordAsync(ChangePasswordDTO newPassword, string email);
}
