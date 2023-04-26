using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.BlogsInterfaces;

public interface IBlogsUpdate
{
    public Task<long> UpdateBlog(Blog blog);
}
