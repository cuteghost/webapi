using Repository.Interfaces.Users.StaffInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.UserDTO.Staff;

namespace Repository.Classes.Users.StaffRepo;

public class StaffRead : IStaffRead
{
    private readonly DentalDBContext _dbContext;
    public StaffRead(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<long> GetStaffUserId(long userId)
    {
        var id = await _dbContext.Staff.AsNoTracking().Where(s=>s.User.Id == userId).Select(s => s.StaffId).FirstOrDefaultAsync();
        return id;
    }
    public async Task<StaffGet> GetStaffMember(long userId)
    {

        var staffMember = await (from staff in _dbContext.Staff
                        where staff.User.Id == userId
                        select new StaffGet
                        {
                            FirstName = staff.User.FirstName,
                            LastName = staff.User.LastName,
                            Education = staff.Education,
                            Languages = staff.Languages,
                            Certification = staff.Certification
                        }).FirstOrDefaultAsync();
        if(staffMember == null)
        {
            return new StaffGet();
        }
        return staffMember;
    }
    public async Task<List<StaffGet>> GetStaffTeam()
    {
        var staffMembers = await ( from staff in _dbContext.Staff
                         select new StaffGet{
                            FirstName = staff.User.FirstName,
                            LastName = staff.User.LastName,
                            Education = staff.Education,
                            Languages = staff.Languages,
                            Certification = staff.Certification
                         }
                         ).ToListAsync();
        return staffMembers;
    }
}
