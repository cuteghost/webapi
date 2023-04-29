using Microsoft.EntityFrameworkCore;
using Repository.Interfaces.Users.StaffInterfaces;
using server.Database;

namespace Repository.Classes.Users.StaffRepo;

public class StaffDelete : IStaffDelete
{
    private readonly DentalDBContext _dbMain;
    public StaffDelete(DentalDBContext dbMain)
    {
        _dbMain=dbMain;
    }
    public async Task<bool> DeleteUser(long userId)
    {
        var staff = await _dbMain.Staff.AsNoTracking().Include(s=>s.User).FirstOrDefaultAsync(s=>s.User.Id == userId);
        if(staff == null) { return false; }
        _dbMain.Staff.Remove(staff);
        _dbMain.Users.Remove(staff.User);
        await _dbMain.SaveChangesAsync();
        return true;
    }
}
