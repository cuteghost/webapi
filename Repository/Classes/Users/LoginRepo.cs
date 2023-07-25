using Repository.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.AuthDTO;
using Models.Domain;
using System.Text;
using System.Security.Cryptography;
using Services.HashService;

namespace Repository.Classes.Users;
public class LoginRepo : ILoginRepo
{
    private readonly DentalDBContext _dbContext;
    private readonly IHashService _hasher;

    public LoginRepo(DentalDBContext dbContext, IHashService hasher)
    {
        this._dbContext = dbContext;
        this._hasher = hasher;
    }
    public async Task<User> Login(LoginDTO user)
    {
        user.Password = _hasher.Hash(user.Password);
        var _user = await _dbContext.Users.AsNoTracking().Where(s => s.Email == user.Email && s.Password == user.Password).FirstOrDefaultAsync();
        if (_user != null)
        {
            user.FirstName = _user.FirstName;
            user.LastName = _user.LastName;
            return _user;
        }

        return null;
    }
}
