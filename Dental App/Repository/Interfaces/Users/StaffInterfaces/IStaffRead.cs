namespace Dental_App.Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffRead
{
    public Task<long> GetStaffUserId(long userId);
}
