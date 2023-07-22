using Models.Domain;
using Repository.Interfaces.Users.StaffInterfaces;
using server.Database;
using Services.HashService;

namespace Repository.Classes.Users.StaffRepo;


public class StaffCreate : IStaffCreate
{
	private readonly DentalDBContext _dbContext;
    private readonly IHashService _hasher;

	public StaffCreate(DentalDBContext dbContext, IHashService hasher)
	{
		_dbContext = dbContext;
		_hasher = hasher;
	}
    public async Task<long> CreateStaffAsync(User newUser, Staff newStaff)
    {
		try
		{
            newUser.Password = _hasher.Hash(newUser.Password);
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
