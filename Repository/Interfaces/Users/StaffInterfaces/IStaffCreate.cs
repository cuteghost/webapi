using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffCreate
{
    public Task<long> CreateStaffAsync(User newUser,Staff newStaff);
}
