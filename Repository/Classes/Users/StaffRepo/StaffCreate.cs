using Dental_App.Models.Domain;
using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using server.Database;

namespace Dental_App.Repository.Interfaces.Users.StaffRepo;


public class StaffCreate : IStaffCreate
{
	private readonly DentalDBContext _dbContext;
	public StaffCreate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}
    public async Task<long> CreateStaffAsync(User newUser, Staff newStaff)
    {
		try
		{
			await _dbContext.Users.AddAsync(newUser);
			await _dbContext.SaveChangesAsync();
			
			newStaff.User = newUser;

			await _dbContext.Staff.AddAsync(newStaff);
			await _dbContext.SaveChangesAsync();

			return newUser.Id;
		}
		catch (Exception)
		{

			throw;
		}
    }
}
