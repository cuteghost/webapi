using Repository.Interfaces.BlogsInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Repository.Classes.BlogsRepo;
public class BlogsDelete : IBlogsDelete
{
    private readonly DentalDBContext _dbContext;
    public BlogsDelete(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<long> DeleteBlog(long blogId)
    {
        var blog = await _dbContext.Blogs.FirstAsync(s => s.Id == blogId);
        _dbContext.Remove(blog);
        await _dbContext.SaveChangesAsync();
        return blogId;
    }
}
