using Models.Domain;
namespace Repository.Interfaces.BlogsInterfaces;

public interface IBlogsRead
{
    public Task<List<Blog>> GetAllTitles();
    public Task<Blog> GetBlogDetails(long blogId);
    public Task<long> BlogExists(long blogID);
}
