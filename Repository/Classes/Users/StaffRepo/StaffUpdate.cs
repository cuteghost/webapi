using Models.Domain;
using Repository.Interfaces.Users.StaffInterfaces;
using server.Database;

namespace Repository.Classes.Users.StaffRepo;
public class StaffUpdate : IStaffUpdate
{
    private readonly DentalDBContext _dbContext;

	public StaffUpdate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task<long> UpdateStaffAsync(User user, Models.Domain.Staff staff)
	{
		try
		{
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
