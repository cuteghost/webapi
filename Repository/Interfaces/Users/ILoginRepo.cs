using Models.DTO.AuthDTO;
using Models.Domain;

namespace Repository.Interfaces.Users;
public interface ILoginRepo
{
    public Task<User> Login(LoginDTO user);
}
