using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffUpdate
{
    public Task<long> UpdateStaffAsync(User user, Staff staff);
}
