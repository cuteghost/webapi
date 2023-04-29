namespace Repository.Interfaces.Users.StaffInterfaces;

public interface IStaffDelete
{
    public Task<bool> DeleteUser(long userId);
}
