using Repository.Interfaces.Users.StaffInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;
using Models.DTO.UserDTO.Staff;
using Models.Domain;

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
    public async Task<StaffGet> GetStaffMember(long staffId)
    {

        var staffMember = await (from staff in _dbContext.Staff
                        where staff.StaffId == staffId
                        select new StaffGet
                        {
                            FirstName = staff.User.FirstName,
                            LastName = staff.User.LastName,
                            // Education = staff.Education,
                            Languages = staff.Languages,
                        }).FirstOrDefaultAsync();
        if(staffMember == null)
        {
            return new StaffGet();
        }
        return staffMember;
    }
    public async Task<Staff> GetStaffObjectMember(long staffId)
    {
        return await _dbContext.Staff.Include(s => s.User).FirstOrDefaultAsync(s => s.StaffId == staffId);
    }
    public async Task<List<StaffGet>> GetStaffTeam()
    {
        var staffMembers = await ( from staff in _dbContext.Staff
                         select new StaffGet{
                            FirstName = staff.User.FirstName,
                            LastName = staff.User.LastName,
                            Email = staff.User.Email,
                            // Education = staff.Education,
                            Languages = staff.Languages,
                         }
                         ).ToListAsync();
        return staffMembers;
    }

    public async Task<StaffGet> GetStaffByEmail(string email)
    {
         var query = await (from staff in _dbContext.Staff
                           join users in _dbContext.Users on staff.User equals users
                           where users.Email == email
                           select new
                           {
                               Id = staff.User.Id,
                               FirstName = users.FirstName,
                               Lastname = users.LastName,
                               BirthDate = users.BirthDate,
                               Gender = users.Gender,
                               Email = users.Email,
                               JMBG = users.JMBG,
                            //    Education = staff.Education
                           }).FirstOrDefaultAsync();
        StaffGet staffMember = new()
        {
            Id = query.Id,
            FirstName = query.FirstName,
            LastName = query.Lastname,
            birthDate = query.BirthDate,
            Gender = Convert.ToInt16(query.Gender),
            Email = query.Email,
            JMBG = query.JMBG,
            // Education = query.Education,

        };

        return staffMember;
    }
}
