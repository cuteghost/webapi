using Models.Domain;

namespace Repository.Interfaces.BlogsInterfaces;

public interface IBlogsUpdate
{
    public Task<long> UpdateBlog(Blog blog);
}
