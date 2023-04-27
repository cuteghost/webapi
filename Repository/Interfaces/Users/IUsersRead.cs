namespace Repository.Interfaces.Users;
public interface IUsersRead
{
    public Task<long> GetUserByJMBG(string jmbg);
    public Task<long> GetUserByEmail(string email);
}
