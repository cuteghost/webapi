using Models.Domain;

namespace Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffCreate
{
    public Task<long> CreateStaffAsync(User newUser,Staff newStaff);
}
