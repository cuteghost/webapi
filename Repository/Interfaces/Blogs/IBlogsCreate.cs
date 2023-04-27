using Models.Domain;

namespace Repository.Interfaces.BlogsInterfaces;

public interface IBlogsCreate
{
    public Task<long> CreateBlog(Blog newBlog);
}
