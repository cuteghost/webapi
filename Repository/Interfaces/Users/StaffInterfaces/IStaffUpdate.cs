using Models.Domain;

namespace Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffUpdate
{
    public Task<long> UpdateStaffAsync(User user, Staff staff);
}
