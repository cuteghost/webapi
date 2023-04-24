using Dental_App.Models.Domain;

namespace Dental_App.Repository.Interfaces.BlogsInterfaces;

public interface IBlogsCreate
{
    public Task<long> CreateBlog(Blog newBlog);
}
