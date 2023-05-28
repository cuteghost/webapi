using Repository.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.AuthDTO;
using Models.Domain;
using System.Text;
using System.Security.Cryptography;

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
        user.Password = HashPassword(user.Password);
        var _user = await _dbContext.Users.AsNoTracking().Where(s => s.Email == user.Email && s.Password == user.Password).FirstOrDefaultAsync();
        if(_user != null)
        {
            user.FirstName = _user.FirstName;
            user.LastName = _user.LastName;
            return _user;
        }

        return null;
    }
    public string HashPassword(string password)
    {
        StringBuilder Sb = new StringBuilder();


        using (SHA256 hash = SHA256Managed.Create()) {

            Encoding enc = Encoding.UTF8;

            Byte[] result = hash.ComputeHash(enc.GetBytes(password));


            foreach (Byte b in result)

            Sb.Append(b.ToString("x2"));

        }
        return Sb.ToString();   
    }

    
}
