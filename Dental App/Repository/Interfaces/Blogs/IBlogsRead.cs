using Dental_App.Models.Domain;
namespace Dental_App.Repository.Interfaces.BlogsInterfaces;

public interface IBlogsRead
{
    public Task<List<Blog>> GetAllTitles();
    public Task<Blog> GetBlogDetails(long blogId);
}
