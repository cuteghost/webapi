using Repository.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.AuthDTO;
using Models.Domain;

namespace Repository.Classes.Users;
public class LoginRepo : ILoginRepo
{
    private readonly DentalDBContext _dbContext;
    public LoginRepo(DentalDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<User> Login(LoginDTO user)
    {
        var _user = await _dbContext.Users.AsNoTracking().Where(s => s.Email == user.Email && s.Password == user.Password).FirstOrDefaultAsync();
        if(user != null)
            return _user;

        return null;
    }

    
}
