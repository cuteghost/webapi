using Models.Domain;
using Repository.Interfaces.Users.StaffInterfaces;
using server.Database;
using Microsoft.EntityFrameworkCore;


namespace Repository.Classes.Users.StaffRepo;
public class StaffUpdate : IStaffUpdate
{
    private readonly DentalDBContext _dbContext;

	public StaffUpdate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<long> UpdateStaffAsync(User user, Staff staff)
	{
		try
		{
			var userFromDb = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(s => s.Email == staff.User.Email);
			var password = userFromDb.Password;
			staff.User.Password = password;

            _dbContext.Update(staff);
            await _dbContext.SaveChangesAsync();

			return user.Id;
        }
        catch (Exception)
		{

			throw;
		}
	}
}
