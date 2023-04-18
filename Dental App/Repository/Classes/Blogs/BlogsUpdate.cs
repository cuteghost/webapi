using Dental_App.Models.Domain;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using server.Database;

namespace Dental_App.Repository.Classes.BlogsRepo;
public class BlogsUpdate : IBlogsUpdate
{
    private readonly DentalDBContext _dbContext;
    public BlogsUpdate(DentalDBContext dBContext)
    {
        _dbContext = dBContext; 
    }
    public async Task<long> UpdateBlog(Blog blog)
    {
        _dbContext.Update(blog);
        await _dbContext.SaveChangesAsync();
        return blog.Id;
    }
}
