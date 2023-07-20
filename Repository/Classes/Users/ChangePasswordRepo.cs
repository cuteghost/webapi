using Repository.Interfaces.Users;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.AuthDTO;
using Services.HashService;

namespace Repository.Classes.Users;
public class ChangePasswordRepo : IChangePassword
{
    private readonly DentalDBContext _dbContext;
    private readonly IHashService _hasher;

    public ChangePasswordRepo(DentalDBContext dbContext, IHashService hasher)
    {
        this._dbContext = dbContext;
        this._hasher = hasher;
    }

    public async Task<bool> ChangePasswordAsync(ChangePasswordDTO newPassword, string email)
    {
        var user = await _dbContext.Users.Where(s => s.Email == email && s.Password == _hasher.Hash(newPassword.oldPassword)).FirstOrDefaultAsync();
        if(user != null)
        {
            user.Password = _hasher.Hash(newPassword.newPassword);
            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

}
