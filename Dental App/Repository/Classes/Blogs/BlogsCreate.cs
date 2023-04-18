using Dental_App.Models.Domain;
using Dental_App.Repository.Interfaces.BlogsInterfaces;
using server.Database;

namespace Dental_App.Repository.Classes.BlogsRepo;
public class BlogsCreate : IBlogsCreate
{
    private readonly DentalDBContext _dbContext;
	public BlogsCreate(DentalDBContext dbContext)
	{
		_dbContext = dbContext;
	}
    public async Task<long> CreateBlog(Blog newBlog)
	{
		await _dbContext.AddAsync(newBlog);
		await _dbContext.SaveChangesAsync();

		return newBlog.Id;
	}
}
