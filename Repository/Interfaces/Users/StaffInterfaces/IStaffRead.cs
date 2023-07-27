using Models.Domain;
using Models.DTO.UserDTO.Staff;

namespace Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffRead
{
    public Task<long> GetStaffUserId(long userId);
    public Task<StaffGet> GetStaffMember(long userId);
    public Task<Staff> GetStaffObjectMember(long staffId);
    public Task<List<StaffGet>> GetStaffTeam();

    public Task<StaffGet> GetStaffByEmail(string email);
}
