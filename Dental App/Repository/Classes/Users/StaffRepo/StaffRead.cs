using Dental_App.Repository.Interfaces.Users.StaffInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Dental_App.Repository.Classes.Users.Staff;

public class StaffRead : IStaffRead
{
    private readonly DentalDBContext _dbContext;
    public StaffRead(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<long> GetStaffUserId(long userId)
    {
        var id = await _dbContext.Staff.AsNoTracking().Where(s=>s.User.Id == userId).Select(s => s.StaffId).FirstAsync();
        return id;
    }
}
