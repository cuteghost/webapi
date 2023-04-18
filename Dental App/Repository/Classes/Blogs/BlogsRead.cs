using Dental_App.Models.Domain;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace Dental_App.Repository.Classes.BlogsRepo;
public class BlogsRead : IBlogsRead
{
    private readonly DentalDBContext _dbContext;
    public BlogsRead(DentalDBContext dBContext)
    {
        _dbContext = dBContext;
    }
    public async Task<List<Blog>> GetAllTitles()
    {
        //TODO: Kreirati DTO za Titlove ili vratiti samo ovdje titlove???
        var blogTitles = await _dbContext.Blogs.AsNoTracking().ToListAsync();
        return  blogTitles;
    }
    public async Task<Blog> GetBlogDetails(long blogId)
    {
        var blogTitles = await _dbContext.Blogs.AsNoTracking().FirstAsync(s=>s.Id == blogId);
        return blogTitles;
    }
    public async Task<long> BlogExists(long blogID)
    {
        var id = await _dbContext.Blogs.AsNoTracking().Where(s => s.Id == blogID).Select(s => s.Id).FirstAsync();
        return id;
    }
}
